    	using (StreamReader reader = new StreamReader(databaseScriptFile)) 
          {
              DatabaseFactory.CreateDatabase(); 
              Database db = new SqlDatabase(connectionstring); 
              txbuilder = new StringBuilder(); 
              bool lastExecute = true;
              string useDB = "";   
              while (!reader.EndOfStream) 
              { 
                  text = reader.ReadLine();
                  if (text.Substring(0, 3) == "USE")
                  {
                      useDB = text;
                  }
                  else if (text.Trim().ToUpper() != "GO") 
                  { 
                      lastExecute = false; 
                      txbuilder.AppendLine(text); 
                  } 
                  else 
                  { 
                      lastExecute = true;
                      strQuery = useDB + txbuilder.ToString();
                      db.ExecuteNonQuery(CommandType.Text, strQuery); 
                      txbuilder.Length = 0; 
                  } 
              } 
              //Make sure that the last sentence is executed 
              if (!lastExecute) 
                  db.ExecuteNonQuery(CommandType.Text, txbuilder.ToString()); 
          }
