    public void DeleteSpiritUser(string nick)
    {
        var user = (from u in _dc.Spirit_Users 
                    where u.Nick == nick 
                    select u).FirstOrDefault();
        if(user != null)
        {
           using (var scope = new TransactionScope())
           {
               _dc.Spirit_Users.DeleteOnSubmit(user);
               _dc.SubmitChanges();
               scope.Complete();
           }
       }
    }
