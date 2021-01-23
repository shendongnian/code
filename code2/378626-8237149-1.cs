            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                int n = i;
                tasks.Add(Task.Factory.StartNew(() => TaskTest(n)));
            }
            Task.WaitAll(tasks.ToArray());
