    public class myClass
    {
        private int[] _Array = new int[10];
        public int this[int index]
        {
            get { return _Array[index]; }
            set
            {
                if (value >= 0 && value <= 10)
                    _Array[index] = value;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            myClass m = new myClass();
            m[0] = 1;
            m[1] = 12;
            Console.WriteLine(m[0]); // outputs 1
            Console.WriteLine(m[1]); // outputs default value 0
        }
    }
