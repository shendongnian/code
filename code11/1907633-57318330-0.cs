    private static void CreateFile(string filePath)
    {
        if (File.Exists(filePath)) File.Delete(filePath);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        var fileLines = new List<string>
        {
            "Message = ",
            "I weigh nothing, but you can still see me.",
            "If you put me in a bucket, I make the bucket lighter.",
            "What am I?",
            "Answer = A hole",
            "Message = ",
            "What’s the difference between",
            "a hippo and a Zippo?",
            "Answer = ",
            "A hippo is really heavy, ",
            "and a Zippo is a little lighter."
        };
        File.WriteAllLines(filePath, fileLines);
    }
    private static void Main()
    {
        // Set this to a file that doesn't exist or that you don't care about
        var filePath = @"f:\private\temp\temp.txt";
        // Create a file with multi-line messages
        CreateFile(filePath);
        // Read all the file text
        var fileText = File.ReadAllText(filePath);
        // Split it into the message/answers
        var messageAnswers = fileText.Split(new[] {"Message ="}, 
            StringSplitOptions.RemoveEmptyEntries);
        // Split each message into a message/answer array
        foreach (var messageAnswer in messageAnswers)
        {
            var parts = messageAnswer.Split(new[] {"Answer ="}, 
                StringSplitOptions.RemoveEmptyEntries);
            var message = parts[0].Trim();
            var answer = parts.Length > 1 ? parts[1].Trim() : "";
            Console.WriteLine(message);
            var userResponse = Console.ReadLine().Trim();
            if (userResponse.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("The actual answer is: " + answer);
            }
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
