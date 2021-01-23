    using System.Data.OleDb;
    DataTable dt= new DataTable();
    OleDbDataAdapter adapter = new OleDbDataAdapter();
    adapter.Fill(dt, Dts.Variables["User::transactionalRepDBs"].Value);
 
    foreach (DataRow row in dt.Rows)
    {
       //insert what you want to do here
    }
