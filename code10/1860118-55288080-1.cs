    public class X
        {
        public Boolean M1 (Int32 x1)
            {
            return M2 (x1);
            }
        public virtual Boolean M2 (Int32 x2)
            {
            return M3 (x2);
            }
        public static Boolean M3 (Int32 x2)
            {
            return x2 >= 0;
            }
        }
    
    public class Y : X
        {
        public override Boolean M2 (Int32 x2)
            {
            return M3 (x2);
            }
        public static new Boolean M3 (Int32 x2)
            {
            return x2 < 0;
            }
        }
