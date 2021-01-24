    public class BOX
    {
        public double Height{get;set;}
        public double Length{get;set;}
        public double Breadth{get;set;}
        public static bool operator == (BOX b1, BOX b2)
        {
            if ((object)b1 == null)
                return (object)b2 == null;
            return b1.Equals(b2);
        }
        ...
