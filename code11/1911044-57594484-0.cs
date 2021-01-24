    int lineNumber = 0;
    string line;
    Console.Write("Input your search text: ");
    string text = Console.ReadLine();
    string otherValue = null;
    using (var reader = new StreamReader("SampleInput1.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            int index = line.IndexOf(text);
            if (index > -1)
            {
                otherValue = line.Substring(index);
                break;
            }
            
            lineNumber++;
        }
    }
    
    if (otherValue == null)
    {
        Console.WriteLine("Not found");
    }
    else
    {
        Console.WriteLine("Line number: {0}", lineNumber);
        Console.WriteLine("Other value: '{0}'", otherValue);
    }
