        public void InsertPersonAndPhoneNumber(int personId, string name, string phone)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./contacts.accdb";
            OleDbConnection cn = new OleDbConnection(connectionString);
            try
            {
                cn.Open();
                OleDbTransaction trans = cn.BeginTransaction();
                try
                {
                    //first transaction ...
                    string sql1 = "INSERT INTO People (ID, pname) VALUES (@ID, @pname)";
                    OleDbCommand cmd1 = new OleDbCommand(sql1, cn, trans);
                    cmd1.Parameters.AddWithValue("@ID", personId);
                    cmd1.Parameters.AddWithValue("@pname", name);
                    cmd1.ExecuteNonQuery();
                    //first transaction ...
                    string sql2 = "INSERT INTO PhoneNumbers (PID, num) VALUES (@PID, @num)";
                    OleDbCommand cmd2 = new OleDbCommand(sql2, cn, trans);
                    cmd2.Parameters.AddWithValue("@PID", personId);
                    cmd2.Parameters.AddWithValue("@num", phone);
                    cmd2.ExecuteNonQuery();
                    trans.Commit();
                    Console.WriteLine("New Contact Added successfully ...");
                }
                catch (Exception x)
                {
                    //handle exception .... 
                    trans.Rollback();
                    Console.WriteLine(x.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            catch (Exception x)
            {
				//handle exception .... 
                
            }
            
        }
        
