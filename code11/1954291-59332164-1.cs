        public void SaveAccount(Account account)
        {
 
            if(File.Exists(@"c:\account.json"))
            {
                //Read it
                Account acc = JsonConvert.DeserializeObject<Account>(File.ReadAllText(@"c:\account.json"));
                //Mod it
                acc.AccountNumber = 0;
                acc.Balance = 0;
                acc.Name = "";
                acc._Type = "";
                //Save it
                File.WriteAllText(@"c:\account.json", JsonConvert.SerializeObject(acc));
            }
            else
            {
                // Create it
                File.WriteAllText(@"c:\account.json", JsonConvert.SerializeObject(account));
            }
        }
