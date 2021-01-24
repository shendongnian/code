    private void txtProductId_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var pathName = txtFilePath.Text;                      
            var fileName = Path.GetFileNameWithoutExtension(pathName);
            var tbContainer = new DataTable();
            var strConn = MsXlConnStr(pathName);
            var sheetName = fileName;
            var bindingSource = new BindingSource();            //Initiated new binding source
            var fieldSelector = "[ProductID], [ProductName], [MRP]";
            var query = $"SELECT {fieldSelector} FROM [{sheetName}$A1:F15535] WHERE [ProductID] = {Convert.ToInt32(txtProductId.Text)}";
            if (!File.Exists(pathName)) throw new Exception("Error, file doesn't exists!");
            dataGridView1.AllowUserToAddRows = false;           //Prevent user from adding new rows manually
            dataGridView1.DataSource = bindingSource;           //Linked the binding source to your dgview
            using (OleDbConnection cnnxls = new OleDbConnection(strConn))
                using (OleDbDataAdapter oda = new OleDbDataAdapter(query, cnnxls))
                {
                    oda.Fill(tbContainer);
                    bindingSource.DataSource = tbContainer;     //Display the results via the datasource               
                }
            if (!dataGridView1.Columns.Contains("newTextCol"))  //Create new textbox column
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add("newTextCol", "foo");
            }
            e.Handled = true;
        }
    }
    private string MsXlConnStr(string pathName)
    {
        return new FileInfo(pathName).Extension.ToLower().Contains(".xlsx") ? 
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'" : 
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
    }
