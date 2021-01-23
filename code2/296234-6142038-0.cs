    public class ExampleClass
    {
        public int InstanceNumber { get; set; }
        public static void HelpMe()
        {
            Console.WriteLine("I'm helping you.");
            // can't access InstanceNumber, which is an instance member, from a static method.
        }
        public int Work()
        {
            return InstanceNumber * 10;
        }
    }
   
