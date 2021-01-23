    [Serializable]
    public class UserIDPair
    {
        public string Name {get;set;}
        public int ID {get;set;}
    }
    var q = (from u in dbContext.Users
        select new UserIDPair
        {
            Name = u.Name,
            Id = u.RowId
        });
    cache.Put(“test”, q.ToList());
