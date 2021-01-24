    try
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "XML Files, Text Files, Excel Files|*.xlsx; *.xls; *.xml; *.txt; ";
        openFileDialog1.Multiselect = true;
        DataTable table = new DataTable();
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            foreach (String file in openFileDialog1.FileNames)
            {
                //tb_path is textbox
                tb_path.Text = file;
                // excelFilePath_com = tb_path.Text;
                string constr = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + tb_path.Text + ";Extended Properties = \"Excel 12.0; HDR=Yes;\"; ");
                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                DataTable dt1 = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                table.Merge(dt1);
            }
        }
        dataGridView1.DataSource = table;
