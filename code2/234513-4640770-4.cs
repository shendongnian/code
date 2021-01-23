    namespace ExecuteStoredProc
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                SqlConnection cnnUserMan;
                SqlCommand cmmUser;
                SqlDataReader drdUser;
    
                //Instantiate and open the connection
                using(cnnUserMan = new SqlConnection("Your connection string")) 
                {
                    cnnUserMan.Open();
    
                    //Instantiate and initialize command
                    using(cmmUser = new SqlCommand("SelectID", cnnUserMan))
                    {
                        cmmUser.CommandType = System.Data.CommandType.StoredProcedure;
    
                        using(drdUser = cmmUser.ExecuteReader())
                        {                     
                            while(drdUser.Read())
                            {
                                Console.WriteLine(String.Format("{0} {1} {2}", drdUser[0], drdUser[1], drdUser[2]);
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
    }
