    public class CompareUser : IComparer<User>
    {
        public User o;
    
        public CompareUser(User p)
        {
            o = p;
        }
    
        public int Compare(User o1, User o2)
        {
            return (o1.Tags.Intersect(o.Tags).Count() < o2.Tags.Intersect(o.Tags).Count()) ?
                1 : -1;            
        }
    }
