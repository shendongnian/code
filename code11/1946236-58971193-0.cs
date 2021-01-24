    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        foreach (String file in openFileDialog1.FileNames)
        {
            //tb_path is textbox
            tb_path.Text = file;
            // excelFilePath_com = tb_path.Text;
            string constr = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + tb_path.Text + ";Extended Properties = \"Excel 12.0; HDR=Yes;\"; ");
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            drop_down_sheet.DataSource = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //dro_down_sheet is combobox to choose which sheet to import 
            drop_down_sheet.DisplayMember = "TABLE_NAME";
            drop_down_sheet.ValueMember = "TABLE_NAME";
        }
    }
