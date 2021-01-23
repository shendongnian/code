    static void displayBooks(string[] titles)
    {
        // Go over each value.
        foreach (string title in titles)
        {
            // And write it out.
            Console.WriteLine(title);
        }
    }
    // In Main()
    displayBooks(titles);
