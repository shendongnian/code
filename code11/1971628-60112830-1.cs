    long lines = 0;
    using (StreamReader r = new StreamReader("text.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            lines++;
          //^^^^^^^ here you need to change
            Console.Title = "Count: " + lines;
            Console.WriteLine(Console.Title);
          
        }
    }
