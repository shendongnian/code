    class Program{
      static void Main(string[] args){
        Person p = new Person();
        p.AskAll();
        Console.WriteLine($"Your BMI is {10000.0 * p.Weight / p.Height / p.Height}");
      }
    }
    
