    int n;
    do
    {
      Console.Write("Choose a pyramid height: ");
      n = Int32.Parse(Console.ReadLine());
      if ( n <= 0) Console.WriteLine("Value must be greater than 0.");
    }
    while ( n <= 0 );
