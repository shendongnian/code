    private void Example()
    {
        List<string> customerlist = new List<string>();
        customerlist.Add("co111");
        customerlist.Add("co112");
        customerlist.Add("co114");
    
        // string in SQL needs "'"
        ConvertToSqlString(ref customerlist);
        // use String.Join() to seperate with ","
        var sql = @"SELECT * FROM customerlist 
                    WHERE custid IN (" + String.Join(",",customerlist) + ")";
    }
    
    private void ConvertToSqlString(ref List<string> lst)
    {
        for(int i = 0;i<lst.Count;i++)
        {
            lst[i] = "'" + lst[i] + "'";
        }
    }
