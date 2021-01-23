            // Create tasks
            List<Task> tasks = new List<Task>()
            {
                new Task(() => Console.WriteLine("A")),
                new Task(() => Console.WriteLine("B"))
            };
            // Start them later
            tasks.ForEach(a => a.Start());
