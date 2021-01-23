    public void Linq73() 
    { 
        int[] factorsOf300 = { 2, 2, 3, 5, 5 }; 
      
        int uniqueFactors = factorsOf300.Distinct().Count(); 
      
        Console.WriteLine("There are {0} unique factors of 300.", uniqueFactors); 
    }
