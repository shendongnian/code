    public MapReader(string fName) {
       if (fName == null)
       {
         Console.WriteLine("Input valid file name:");
         fName = Console.ReadLine();
        }
        FileName = fName;
    }
    
    public MapReader() : this (null) {}
