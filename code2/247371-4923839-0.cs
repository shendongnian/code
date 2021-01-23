    using (var textFile = System.IO.File.OpenText("yourfile.dat"))
    {
        string line = null;           
        while ((line = textFile.ReadLine()) != null)
        {
             // Parse line.
        }
    }
