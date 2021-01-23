    public class Test
    {
        public static bool operator ==(Test t1, Test t2)
        {
            // Insert logic here, being careful of the possibility of
            // t1 and t2 being null. And don't just use if (t1 == null)
            // - it will recurse!
        }
        public static bool operator !=(Test t1, Test t2)
        {
            // Usual way of implementing
            return !(t1 == t2);
        }
    }
