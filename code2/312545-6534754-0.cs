    DataTable dt = [whole_table];
    
    int counter = Num_Subjects + 1; //7
    
    string colName = "P" + counter.ToString(); //P7
    
    while(dt.Columns.Contains(colName))
    {
       dt.Columns.Remove(colName);
       colName = "P" + (++counter).ToString()
    }
