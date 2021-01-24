    var map = new int[10, 10];
    using (var reader = new StreamReader("Lode.txt"))  // using will call close automatically
    {
        for (var i = 0; i < 10; i++)
        {
            var line = reader.ReadLine();  // read one line from file
            for (var j = 0; j < 10; j++)
            {
                map[i, j] = Int32.Parse(line[j].ToString());  // get one symbol from current line and convert it to int
            }
        }
    }
