    public class MyClass
    {
        public Type GetType()
        {
            return typeof(Program);
        }
    
    }
    
    class Program {
    
        //this is oversimplified implementation,
        //but I want to show the main differences
        public static bool IsInstOf(object o, Type t)
        {
            //calling GetType on System.Object
            return o.GetType().IsAssignableFrom(t);
        }
    
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
    
            //calling MyClass non-virtual version for GetType method
            if (mc.GetType() == typeof(Program))
            {
                //Yep, this condition is true
                Console.WriteLine("Not surprised!");
            }
    
            //Calling System.Object non-virtual version for GetType method
            if (IsInstOf(mc, typeof(Program)))
            {
                //Nope, this condition isn't met!
                //because mc.GetType() != ((object)mc).GetType()!
            }
            Console.ReadLine();
        }            
    }
