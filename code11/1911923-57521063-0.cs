    public static void AddValueToList()
    {
      _values = new List<double>(); 
      int numberOfValues;
      Console.WriteLine("Enter size of index:");
      numberOfValues = int.Parse(Console.ReadLine());
    
      for ( int i = 0; i < numberOfValues; i++)
      {
          _values.Add(ReadDouble($"Enter the {i + 1}st value:"));
      }
   }
