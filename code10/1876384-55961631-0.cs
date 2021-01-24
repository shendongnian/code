    public LinkedList<Task> GetTasksFromFile(string filePath)
    {
        // This will hold our results from reading the file lines into Tasks
        var tasks = new LinkedList<Task>();
        // Loop through each line in the file 
        foreach (string line in File.ReadLines(filePath))
        {
            // Split the line on the comma and period characters so we get separate values
            string[] parts = line.Split(new[] {'.', ','}, 
                StringSplitOptions.RemoveEmptyEntries);
            // These will hold the parsed values from each line of text in our file
            int lengthHour;
            int lengthMinute;
            int deadlineHour;
            int deadlineMinute;
            // int.TryParse will try to convert a string to an int, and will return 
            // true if successful. It will also set the 'out' parameter to the result.
            // We do this on each part from our line of text 
            // (after ensuring that there are at least 4 parts)
            if (parts.Length > 3 &&
                int.TryParse(parts[0], out lengthHour) &&
                int.TryParse(parts[1], out lengthMinute) &&
                int.TryParse(parts[2], out deadlineHour) &&
                int.TryParse(parts[3], out deadlineMinute))
            {
                // If our parsing succeeded, create a new task
                // with the results and add it to our LinkedList
                TimeSpan length = new TimeSpan(lengthHour, lengthMinute, 0);
                TimeSpan deadline = new TimeSpan(deadlineHour, deadlineMinute, 0);
                Task task = new Task(length, deadline);
                tasks.AddLast(task);
            }
        }
        // Return our linked list back to the caller
        return tasks;
    }
