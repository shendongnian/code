static int num1;
static int num2;
static void Main(string[] args){
    var rand = new Random();
    num1 = rand.Next(10); // Generate random number between 0 and 10
    num2 = rand.Next(10);
    
    Add();
    Subtract();
    
    Console.ReadLine();
}
static void Add(){
    Console.WriteLine($"{num1} + {num2} = {num1+num2}");
}
static void Subtract(){
    Console.WriteLine($"{num1} - {num2} = {num1-num2}");
}
In this example, `num1` and `num2` need to be processed by the `Add()` and `Subtract()` methods, so we make them global variables. The `rand` variable on the other hand is only needed in the `Main()` method, so we keep it local.
Global variables can also be accessed from within other classes (depending on their scope), whereas local variables cannot.
