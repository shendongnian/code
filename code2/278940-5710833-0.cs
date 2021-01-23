    using( StreamReader reader = new StreamReader( @"c:\index.html" ) )
    {
     String line = String.Emtpy;
     while( (line = reader.ReadLine()) != null )
     {
      Console.WriteLine( line );
     }
    }
