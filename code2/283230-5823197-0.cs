    public override bool ValidateUser(string username, string password)
    {
        Guid rsid;
    
        if (Guid.TryParse(username, out rsid))
        {
            return db.ValidateUser(rsid);
        }
        else
        {
            return false;
        }
    }
