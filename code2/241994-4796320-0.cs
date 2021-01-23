    List<string> names = new List<string>();
    names.Add("a.jpg");
    names.Add("b.jpg");
    names.Add("c.jpg");
        
        
    foreach (string name in names)
    {
       OleDbCommand sqlcmd = new OleDbCommand("delete from table1 
       where name not in (" + name + ")", 
       sqlconnection); 
       sqlcmd.ExecuteNonQuery(); 
    }
