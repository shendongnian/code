    StringBuilder buffer = new StringBuilder();
    string line = null;
    using (StreamReader sr = new StreamReader(dataFile))
    {
        while((line = sr.ReadLine()) != null)
        {
            // Do whatever you need to do with the individual line...
            // ...then append the line to your buffer.
            buffer.Append(line); 
        }
    }
    // Now, you can do whatever you need to do with the contents of
    // the buffer.
    string wholeText = buffer.ToString();
