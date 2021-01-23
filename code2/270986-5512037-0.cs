    static private void walk(String name)
    {
        try
        {
            foreach (String pattern in Patterns)
            {
                foreach (String f in Directory.GetFiles(name, pattern))
                {
                    Console.WriteLine(f);
                 } 
            }
                foreach (String d in Directory.GetDirectories(name))
            {
                walk(d);
            }
        }
        catch
        {
        }
  }
