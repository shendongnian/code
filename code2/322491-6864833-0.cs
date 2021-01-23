    string pattern = @"\< *a\=([^\<\>]+) *[\<\>]";
    Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
    Match m = r.Match(tosearch);
    if ( m.Success )
    {
      foreach (Group g in m.Groups)
      {
        Console.WriteLine("Group: " + g.Value);
      }
    }
    else
    {
      Console.WriteLine("No matches");
    }
    Console.WriteLine();
    
    //To keep the console window open after running the application, add the following lines of code:
    System.Console.WriteLine("Press any key to Continue...");
    System.Console.ReadLine();
