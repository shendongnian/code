    public class Transactions
    {
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public int SettingId { get; set; }
    }
    public class Account
    {
        public int Id {get; set;}
        public int Name {get; set;}
    }
    public class User
    {
        public int Id {get; set;}
        public int Name {get; set;}
    }
    public class Setting
    {
        public int Id {get; set;}
        public int Name {get; set;}
    }
