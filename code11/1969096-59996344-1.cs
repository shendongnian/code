     string[] strNumbers = System.IO.File.ReadAllLines(@"C:\MyFolder\Values.txt");
     int count = 0;
     foreach (string strNumber in strNumbers)
     {
       if (Int32.TryParse(strNumber, out int number)) 
       {
          count = count + number;
       }
    }
    
    Console.WriteLine("Total : " +count);
