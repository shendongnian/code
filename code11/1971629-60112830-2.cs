    long lines = 0;
    using (StreamReader r = new StreamReader("text.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            Console.WriteLine(++lines); //One line solution
        }
    }
