    private static void Main()
    {
        var question = "How long is the Mississippi River";
        var questionSplit = question.Split(' ').ToList();
        var key = questionSplit[0];
        // Add the second word if the first one is 'how'
        if (key.Equals("how", StringComparison.OrdinalIgnoreCase))
        {
            key += $" {questionSplit[1]}";
        }
        // This will hold the method we need to call if the key is found
        Func<string, string> methodToInvoke;
        // Try to get the method for this key in our dictionary and then invoke it if found
        if (KeyWordMethodMap.TryGetValue(key, out methodToInvoke))
        {
            Console.WriteLine(methodToInvoke.Invoke(question));
        }
        else
        {
            Console.WriteLine($"Sorry, I don't understand the command: {key}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
