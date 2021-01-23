        // method
        public static Account GetAccount(string nick, ISession session) 
        {   
         var account = (session.QueryOver<Account>().JoinQueryOver<Credentials>(a => a.Credentials).Where(c => c.Nick == nick));   
    
               if (account != null)                      
                return account.SingleOrDefault();                    
        return null;  
        }
    
    // usage
        var actualAccount = LoginDbHelper.GetAccount(nick);   
        actualAccount.Status.AddTime = DateTime.Now;   
        using (var session = NHiberanteHelper.OpenSession())  
        
        LoginDbHelper.SaveOrUpdateAccount(account, session); 
