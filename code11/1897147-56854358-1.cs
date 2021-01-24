    private void AddTasks()
        {
            tasks.AddRange(items
                           .Where(x => x.InProcess == false)
                           .Select(AddTaskAsync)
                           .ToArray());
            //later await Task.WhenAll(tasks);
        }
        private async Task AddTaskAsync(YourClass item)
        {
            await semaphore.WaitAsync();
            try
            {
                await DoWork(item);
            }
            finally
            {
                semaphore.Release();
            }
        }
