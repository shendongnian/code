    DataTable DtShow=new DataTable();
    for (int i = 0; i < DtShow.Rows.Count; i++)
     {
       Console.WriteLine(DtShow.Rows[i].Field<string>(0));
     }
  
    **   Field<string>(0) Column number start from 0
