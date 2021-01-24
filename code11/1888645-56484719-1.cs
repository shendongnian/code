    public bool CheckUser(string username,string password) {
        using(var db = new KeyLockerContext()) {
            
            // Check if that combination already exists in DB.
            var result = db.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            // See if result has a value, SingleOrDefault() returns null if no match
            return (result == null);
        }
    }
