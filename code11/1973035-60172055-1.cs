       static void Main(string[] args) {
         Console.WriteLine("Please, enter your weight in lbs:");
         double lbs = Convert.ToDouble(Console.ReadLine());
    
         Console.WriteLine("Please, enter your height in inches:");
         double inches = Convert.ToDouble(Console.ReadLine()); 
    
         Bmi bmi = new Bmi(inches, lbs);
    
         Console.WriteLine($"You are {bmi.Description}");
    
         Console.ReadKey();
       }  
   
