    bmi = (weight * 703) / Math.Pow(height,2);
    
    if (bmi < 18.5)
    {
      Console.WriteLine("Underweight"); 
    }
    else if (bmi <= 25)
    {
      Console.WriteLine("Optimal");
    }
    else if (bmi > 25)
    {
      Console.WriteLine("Overweight");
    }
