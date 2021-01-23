    StringBuilder sbSQL = new StringBuilder(
           "INSERT INTO [table] ([fk_id], [Description], [Title] ) VALUES");
    
    int paramNum = 0;
    List<object> paramValues = new List<object>();
    
    foreach(var item in items) 
    {
        sbSQL.AppendFormat("({{{0}}},{{{1}}},{{{2}}}),", 
            paramNum, 
            paramNum + 1, 
            paramNum + 2);
    
        paramValues.Add(item.fk_id);
        paramValues.Add(item.description);
        paramValues.Add(item.title);
    
        paramNum += 3;
    }
    
    myDataContext.ExecuteCommand(
        sbSQL.Remove(sbSQL.Length - 1, 1).ToString(), 
        paramValues.ToArray());
