    namespace ConsoleApplication1
    {
        public class UiUtils
        {
            public static int myObject = 1;
            public UiUtils()
            {
                myObject = new int();
                iContext.myObject = myObject;
                Console.WriteLine("This is UiUtils\n");
            }
        }
    
        public class iContext
        {
            public static int myObject = 2;
    
            public iContext()
            {
                Console.WriteLine("This is iContext\n");
            }
    
            public iContext(int myObject)
            {
                myObject = myObject;
            }
        }
    
        public class iContext2 : iContext
        {
            public static int myObject = 3;
    
            public iContext2()
            {
               
                Console.WriteLine(myObject.ToString() + "\nThis is iContext2\n");
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                iContext2 icontext = new iContext2();
                Console.In.ReadLine();
            }
        }
    }
