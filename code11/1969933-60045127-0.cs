    using System;
    namespace TestCalculator
      {
     class MyCalc
    {
    // class variable
    public int x;
    public int z;
    public string y;
    public string n;
    // constructor
    public MyCalc(int x, int z, string y, string n)
      {
      this.x = x;  // assign the parameter passed to the class variable
      this.z = z;
      this.y = y;
      this.n = n;
      }
    // calculate the operations
    public int GetAdd()
      {
      return (this.x + this.z);
      }
    public int GetSubtract()
      {
      return (this.x - this.z);
      }
    public int GetMultiply()
      {
      return (this.x * this.z);
      }
    public int GetDivide()
      {
      return (this.x / this.z);
      }
    public string GetYes()
      {
      return (this.y);
      }
    public string GetNo()
      {
      return (this.n);
      }
    }
     class Program
    {
    static void Main(string[] args)
      {
      bool repeat = false;
      do
        {
        repeat = false;
        int x = 0; int z = 0; string y; string n;
        Console.WriteLine("Enter the First Number");
        x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the Second Number");
        z = Convert.ToInt32(Console.ReadLine());
        //Using a switch statement to perform calculation:
        Console.WriteLine("Enter operator\r");
        switch (Console.ReadLine())
          {
          case "+":
            Console.WriteLine($"The Answer is: {x} + {z} = " + (x + z));
            break;
          case "-":
            Console.WriteLine($"The Answer is: {x} - {z} = " + (x - z));
            break;
          case "*":
            Console.WriteLine($"The Answer is: {x} + {z} = " + (x + z));
            break;
          case "/":
            Console.WriteLine($"The Answer is: {x} - {z} = " + (x - z));
            break;
          }
        //Repeat or Exit program using the do-while loop:
        string input = Console.ReadLine();
        Console.WriteLine("Do you want another operation(Y / N) ?");
        input = Console.ReadLine();
        repeat = (input.ToUpper() == "Y");
        }
      while (repeat);
      Console.WriteLine("Thanks for using our system.");
      Console.ReadKey();
      }
    }
  }
