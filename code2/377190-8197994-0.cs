        int count = 0;
        foreach (var c in subjectString)
        {
            if (!char.IsLetterOrDigit(c)) count++;
        }
        Console.WriteLine("{0}", count);
