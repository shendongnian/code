    public abstract class RegisteredUser : IComparable
    {
        public string Name { get; set; }
        // other properties
        public int CompareTo(object obj)
        {
            if (obj is RegisteredUser user)
                return this.Name.CompareTo(user.Name);
            return 1;
        }
    }
    public class Assistant : RegisteredUser
    {
    }
