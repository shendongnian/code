    public class A
    {
        public void C()
        {
            Console.WriteLine("C called");
        }
    }
    // the extensions class, can be any name, must be public
    public class Extensions
    {
        public static void B(    this                   A                 me)
     // ^ must be public static  ^ indicates extension  ^ type to extend  ^ name of variable instead of this
        {
            Console.WriteLine("B called");
            // instead of this, you use the name of variable you used in the parameters
            me.C();
        }
    }
