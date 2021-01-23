    using (var file = new System.IO.StreamReader("c:\\test.txt"))
    {
        string line;
        while ((line = file.ReadLine()) != null)
        {
            // do something awesome
        }
    }
