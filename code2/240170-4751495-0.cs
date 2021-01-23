    StreamWriter sw = new StreamWriter(path, true);
    while
    {
        // ...
        while( !(working.StartsWith(strEndMarker)))
        {
            sw.WriteLine(working);
            working = sr.ReadLine();
        }
    }
