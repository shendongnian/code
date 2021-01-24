    private void txtProductId_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var pathName = txtFilePath.Text;                      
            var fileName = Path.GetFileNameWithoutExtension(pathName);
            var tbContainer = new DataTable();
            var sheetName = fileName;
            var bindingSource = new BindingSource();            //Initiated new binding source
            var fieldSelector = "[ProductID], [ProductName], [MRP]";
            var query = $"SELECT {fieldSelector} FROM [{sheetName}$A1:F15535] WHERE [ProductID] = {Convert.ToInt32(txtProductId.Text)}";
            if (!File.Exists(pathName)) throw new Exception("Error, file doesn't exists!");
            grdProductList.AllowUserToAddRows = false;           //Prevent user from adding new rows manually
            grdProductList.DataSource = bindingSource;           //Linked the binding source to your dgview
            using (OleDbConnection cnnxls = new OleDbConnection(MsXlConnStr(pathName)))
                using (OleDbDataAdapter oda = new OleDbDataAdapter(query, cnnxls))
                {
                    oda.Fill(tbContainer);
                    bindingSource.DataSource = tbContainer;     //Display the results via the datasource               
                }
            //Create new textbox column
            if (!grdProductList.Columns.Contains("newTextCol"))
                grdProductList.Columns.Add("newTextCol", "foo");
            e.Handled = true;
        }
    }
    private string MsXlConnStr(string pathName)
    {
        return new FileInfo(pathName).Extension.ToLower().Contains(".xlsx") ? 
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'" : 
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
    }
