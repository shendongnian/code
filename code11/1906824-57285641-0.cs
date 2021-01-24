    public class Class1
    {
        public int var1;
        public double var2;
        
        public override string ToString(){
            return "var1 : " + var1 + " var2 : " + var2;
        }
    }
    public class Class2
    {
        public Class1 Method2_1()
        {
            return new Class1
            {
                var1 = 1,
                var2 = 1.1
            };
        }
        public Class1 Method2_2()
        {
            return new Class1
            {
                var1 = 2,
                var2 = 2.2
            };
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            var c1 = new Class2();
            var testM1 = c1.Method2_1();
            var testM2 = c1.Method2_2();
            Console.WriteLine("testM1 : " + testM1.ToString());
            Console.WriteLine("testM2 : " + testM2.ToString());
            
        }
    }
