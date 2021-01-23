    using (StreamWriter LJ = new StreamWriter("C:\\Lob.txt"))
    {
        LJ.WriteLine("XXXXXXXXXXXX");
    
        try
        {
            ...
            LJ.WriteLine("XXXXXXXXXXXX");
        }
        catch (InvalidException)
        {
            LJ.WriteLine("YYYYYYYYYYYYYYYY");
            Console.WriteLine("Error: ");
            return;
        }
    }
