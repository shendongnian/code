    public class Class1
    {
        public static void PrintHellow()
        {
            Console.WriteLine("Hellow!")
        }
    
        public void printGoodBy()
        {
            Console.WriteLine("Good by!")
        }
    
        private void Hidden()
        {
            Console.WriteLine("I am hidden from other classes out there!");
        }
    }
    
    static void Main()
    {
        Class1.PrintHellow();//this is a static method you can call it directly.
    
        //Class1.PreintGoodBy();//This is not valid since the method is not static
    
        Class1 class1Instance = new Class1();
        class1Instance.PrintGoodBy();//this is how to call none static method from a class
    
        //classInstance.Hidden();//this is not valid call since this method marked as private 
    }
