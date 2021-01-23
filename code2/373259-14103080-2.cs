    using System.Data.OleDb;
    DataTable dt= new DataTable();
    OleDbDataAdapter adapter = new OleDbDataAdapter();
    adapter.Fill(dt, Dts.Variables["User::transactionalRepDBs"].Value);
    String _showMe;
 
    foreach (DataRow row in dt.Rows)
    {
       //insert what you want to do here
               for (int i = 0, _showMe = ""; i < row.ItemArray.Length; i++ )
               {
                   _showMe += row.ItemArray[i].ToString() + " | ";
               }
               MessageBox.Show("Data row #" + dt.Rows.IndexOf(row).ToString() + " value: " + _showMe);
    }
