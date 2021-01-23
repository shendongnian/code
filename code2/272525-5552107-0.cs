    public class Base
    {
        public static void RunBase(A a)
        {
            try
            {
                a.RunA();
            }
            catch(SomeSpecialTypeOfException ex)
            { 
                // Do exception handling here
            }
        }
    }
    public class B: A
    {
        public void RunA()
        {
            //statement: exception may occur here
            ...
            // Don't use a try-catch block here. The exception
            // will automatically "bubble up" to RunBase (or any other
            // method that is calling RunA).
        }
    }
