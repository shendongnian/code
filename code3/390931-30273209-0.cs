    Dictionary<int, string>emp = new Dictionary<int, string>();
    OleDbCommand cmd = new OleDbCommand("select empId,Name from Employee where ORDER BY empId DESC", con);
    OleDbDataReader dr = cmd.ExecuteReader();
                
    if (dr.HasRows)
    {
        while (dr.Read())
        {
             emp.Add(Convert.ToInt32(dr["empId"]), dr["Name"].ToString());                
        }                    
    }
    
    foreach (KeyValuePair<int, string> em in emp)
    {
        Console.WriteLine(em.Key.ToString() + " = " + em.Value);
    }
