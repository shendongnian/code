    using (DirectoryEntry entry = new DirectoryEntry())
            {
                entry.Username = "DOMAIN\\LOGINNAME";
                entry.Password = "PASSWORD";
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = "(objectclass=user)";
                try
                {
                    searcher.FindOne();
                    {
                        //Add Your Code if user Found..
                    }
                }
                catch (COMException ex)
                {
                    if (ex.ErrorCode == -2147023570)
                    {
                        ex.Message.ToString();
                        // Login or password is incorrect 
                    }
                }
            }
