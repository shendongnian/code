            var tasks = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                // I want my list of tasks to contain at most 5 tasks at once
                if (tasks.Count == 5)
                {
                    // Wait for at least one of the tasks to complete
                    await Task.WhenAny(tasks.ToArray());
                    // Remove all of the completed tasks from the list
                    tasks = tasks.Where(t => !t.IsCompleted).ToList();
                }
                // Add some task to the list
                tasks.Add(Task.Factory.StartNew(async delegate ()
                    {
                        await Task.Delay(1000);
                    }));
            }
