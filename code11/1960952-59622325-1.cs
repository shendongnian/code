    private DateTime? GetLastLoginDate(string emailAddress)
    {        
        using(var db = new DbClassName())
        {        
            //Find the user
            var user = db.Members.FirstOrDefault(m => m.EmailAddress == emailAddress);
            return user?.Last_Login_Date;
        }
    }
