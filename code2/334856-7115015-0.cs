    Output from B
    Output
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                B writeClass = new B(); 
                writeClass.WriteLine("Output"); // I expect to see 'Output from B' 
                A otherClass = (A)writeClass; 
                otherClass.WriteLine("Output"); // I expect to see just 'Output' 
                Console.ReadKey();
            }
        }
    
        public class A
        {
            public void WriteLine(string toWrite) { Console.WriteLine(toWrite); }
        }
        public class B : A
        {
            public new void WriteLine(string toWrite) { Console.WriteLine(toWrite + " from B"); }
        }
    }
