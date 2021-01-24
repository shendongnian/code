    static enum AvailableSizes
    {
            Small = 1,
            Medium = 2,
            Large = 3,
            Huge = 4
    }
    static int ChoisirCategory()
    {
        int FileSizeType;
     
    GetInput:
        Console.Write("What type do you want: ");
        FileSizeType = Convert.ToInt32(Console.ReadLine());
        
        // Ensure the value is not higher than expected
        // (you could also check that it is not below the minimum value)
        if (FileSizeType > Enum.GetValues(typeof(AvailableSizes)).Cast<int>().Max());
        {
            Console.WriteLine("Value too high.");
            goto GetInput;
        }
        return FileSizeType;
    }
        
    static string NomCategorie(int c)
    {
        if (Enum.IsDefined(typeof(AvailableSizes), c) 
        {
            return (AvailableSizes)c; 
        }
        else 
        {
            return "Invalid category";
        }
    }
