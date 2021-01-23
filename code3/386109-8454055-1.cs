    public class CompareUser : IComparer<User>
    {
        public User o;
    
        public CompareUser(User p)
        {
            o = p;
        }
    
        public int Compare(User o1, User o2)
        {
            return (o1.tag.Intersect(o.tag).Count() < o2.tag.Intersect(o.tag).Count()) ?
                1 : -1;            
        }
    }
