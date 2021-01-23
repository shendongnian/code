     DateTime passwordLastSet = DateTime.FromFileTime((Int64)(result.Properties["PwdLastSet"][0])).ToString();  
        public string lastReset(DateTime pwordLastReset)
            {
                if (DateTime.Now.AddHours(24) <= passwordLastSet)
                {
                    return "try again later";
                }
                else
                {
                    return "all is good";
                }
        
            }
