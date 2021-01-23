    using (var conn = new SqlConnection(strconString))
    {
        string cmdstr = 
            "select status from racpw where vtgid = " + vtgid;
        using (var cmdselect = new SqlCommand(cmdstr, conn))
        {
            conn.Open();
            using(var dtr = cmdselect.ExecuteReader())
            {
                if (dtr.Read())
                {
                    return;
                }
                else
                {
                    ...
                }
            }
        }
    }
