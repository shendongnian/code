            con.Open();
            System.Data.DataSet excelDataSet = new DataSet();
            cmd.Fill(excelDataSet);
            DataTable data = excelDataSet.Tables[0];
            DataRow[] arrdata = data.Select();
            foreach (DataRow rw in arrdata)
            {
                object[] cval = rw.ItemArray;
            }           
            
            con.Close();
            MessageBox.Show (excelDataSet.Tables[0].ToString ()); 
