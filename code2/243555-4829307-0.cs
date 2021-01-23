    List<Manufacturer> mList = ManuImport.GetManufacturers();
    using(TextWriter tw = new StreamWriter(@"C:\manu.txt"))
    {
        foreach (Manufacturer manu in mList)
        {
           //Output name to txt file. 
            tw.WriteLine(manu.ManufacturerName);
            Console.WriteLine(manu.ManufacturerName);
            Console.WriteLine(manu.ShortManufacturerName);
            Console.WriteLine(manu.ManufacturerDirectory);
            Console.WriteLine(manu.ManuId);
            Console.WriteLine("------------------------");
        }
    }
