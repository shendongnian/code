    public static void addNewBillionaire() 
    { 
    	billObj = new Billionaire();
    	Console.WriteLine("Enter name:"); 
    	billObj.Name = Console.ReadLine(); 
    	Console.WriteLine("Enter the income:"); 
    	billObj.Income = int.Parse(Console.ReadLine()); 
    	Console.WriteLine("Enter country:"); 
    	billObj.Country = Console.ReadLine(); 
    	Billionaires.Add(billObj); 
    } 
