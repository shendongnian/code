             // Works Perfectly fine ....ssis , c#
                 DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.Fill(dt, Dts.Variables["User::VariableObj"].Value);
            foreach (DataColumn cols in dt.Columns)
            {
                MessageBox.Show("Colum Name = " + cols.ToString());
            }
         
                foreach (DataRow row in dt.Rows)
                {
                  
                    MessageBox.Show( "rows ID =  " + row[0].ToString() + " rows       
                    Name =  " + row[1].ToString());
                  }
