    public class MyClass {
        public static int number = 15;
    
        public void DoSomething(int number) {
            Console.WriteLine(this.number); // prints value of "MyClass.number"
            Console.WriteLine(MyClass.number); // prints value of "number" parameter
        }
    }
