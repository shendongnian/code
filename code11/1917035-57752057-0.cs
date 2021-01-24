    public static class Test
    {
        public static bool UserCheck(this object a)
        {
            return a != null;//ha-ha
        }
    }
    public class SomeProgramm
    {
        public void main()
        {
            int a = 0;
            a.UserCheck();
            object b = new object();
            b.UserCheck();
        }
    }
