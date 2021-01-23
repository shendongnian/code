    int numLastLinesToIgnore = 10;
    string line = null;
    Queue<string> deferredLines = new Queue<string>();
    using (TextReader inputReader = new StreamReader(inputStream))
    using (TextWriter outputReader = new StreamWriter(outputStream))
    {
        while ((line = inputReader.ReadLine()) != null)
        {
            if (deferredLines.Count() == numLastLinesToIgnore)
            {
                outputReader.WriteLine(deferredLines.Dequeue());
            }
    
            deferredLines.Enqueue(line);
        }
        // At this point, lines still in Queue get lost and won't be written
    }
    
