    public class TestClass
    {
        int indexcounter = 3;
        public int returnInteger()
        {
            int temporarystorage = indexcounter;
            indexcounter --;
            return temporarystorage;
        }
        // I've added that property so that we can inspect the value of indexcounter outside this class
        public int IndexCounter {get {return indexcounter;} }
        
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = new TestClass();
            
            Console.WriteLine(a.IndexCounter); // prints 3
            
            Console.WriteLine(a.returnInteger()); // prints 3
            
            Console.WriteLine(a.IndexCounter); // prints 2
            
            Console.WriteLine(a.returnInteger()); // prints 2
            
            Console.WriteLine(a.IndexCounter); // prints 1
        }
    }
