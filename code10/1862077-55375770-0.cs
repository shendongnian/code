       public void MakeConnection()
            {
                string ConnectionString = "Database=databasename;Host=ipaddress;Server=servername;Service=port;Protocol = olsoctcp; UID = userid; Password = password;";
                IfxConnection conn = new IfxConnection();
                conn.ConnectionString = ConnectionString;
                conn.ClientLocale = "en_US.UTF8";
                conn.DatabaseLocale = "en_US.UTF8";
                try
                {
                    conn.Open();
                }
                catch (IfxException ex)
                {
                    Console.WriteLine(ex.ToString());
                }    
                Console.ReadLine();
            }
