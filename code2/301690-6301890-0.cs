    [TableName("Users")]
    [PrimaryKey("Id")]
    public class User {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    var user = new User() { Name = "My Name" };
    db.Insert(user);
