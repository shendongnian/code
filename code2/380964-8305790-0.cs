           try {
             Reader = command.ExecuteReader();
             if (Reader.Read())
              {
                  return Reader.GetValue(0) as Byte[];
              }
            } finally {
               MySqlCon.Close();
            }
