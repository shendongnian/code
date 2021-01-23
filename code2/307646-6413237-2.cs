    public class User
    {
        public int UserID { get; set; }
        public bool IsUser(object obj) 
        {
            return (obj is User && ((User)obj).UserID == this.UserID);
        }
    }
