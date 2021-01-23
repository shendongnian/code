    static public class IntExtMethods
    {
        public static int ui(this uint a)
        {
            return unchecked((int)a);
        }
    }
