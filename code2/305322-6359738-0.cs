    public class MyClass {
        public int number = 15;
    
        public void DoSomething(int number) {
            Console.WriteLine(this.number); // prints value of "MyClass.number"
            Console.WriteLine(number); // prints value of "number" parameter
        }
    }
