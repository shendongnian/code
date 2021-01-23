    public class mystring : mydatatype
    {
        public string mystrings{ get; set; }
        public override string ToString()
        {
            return mystrings;
        }
    }
    public class myint : mydatatype
    {
        public int myints{ get; set; }
        public override string ToString()
        {
            return myints.ToString();
        }
    }
    public class mydouble : mydatatype
    {
        public double mydoubles{ get; set; }
        public override string ToString()
        {
            return mydoubles.ToString();
        }
    }
