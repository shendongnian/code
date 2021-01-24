    public void SaveAccount(Account account)
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
