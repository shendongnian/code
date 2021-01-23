     public static void MapUserToAllTheDatabases(String Server, String Server_UserName, String Server_Password, String LoginName,String user_Username)
        {
            ServerConnection conn = new ServerConnection(Server, Server_UserName, Server_Password);
            Server srv = new Server(conn);
            DatabaseCollection dbs = srv.Databases;
            foreach (Database d in dbs)
            {
                bool ifExists = false;
                foreach (User user in d.Users)
                    if (user.Name == user_Username)
                        ifExists = true;
                if (ifExists == false)
                {
                    User u = new User(d, user_Username);
                    u.Login = LoginName;
                    u.Create();
                    u.AddToRole("db_owner");
                }
            }
            srv.Refresh();
        }
