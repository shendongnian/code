     OleDbCommand sqlcmdCommand1 = new OleDbCommand("select stmt", sqlconConnection);
            sqlcmdCommand1.CommandType = CommandType.Text;
            try
            {
                sqlconConnection.Open();
                OleDbDataReader sdaResult = sqlcmdCommand1.ExecuteReader();
                myclass a = new myclass();
                while (sdaResult.Read())
                {
                    
                   a.i = sdaResult.GetString(2);
                   or 
                   int i = sdaResult.GetString(2)); 
                  // 2 is the index of your column, in general start from 0;'
                }
