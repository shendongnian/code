        void Main()
        {
            const int inputCollectionBufferSize = 1024;
            const int bulkInsertBufferCapacity = 100;
            const int bulkInsertConcurrency = 4;
            BlockingCollection<object> inputCollection = new BlockingCollection<object>(inputCollectionBufferSize);
            Task loadTask = Task.Factory.StartNew(() =>
            {
                foreach (object nextItem in ReadAllElements(...))
                {
                    // this will potentially block if there are already enough items
                    inputCollection.Add(nextItem);
                }
                // mark this collection as done
                inputCollection.CompleteAdding();
            });
            Action parseAction = () =>
            {
                List<object> bulkInsertBuffer = new List<object>(bulkInsertBufferCapacity);
                foreach (object nextItem in inputCollection.GetConsumingEnumerable())
                {
                    if (bulkInsertBuffer.Length == bulkInsertBufferCapacity)
                    {
                        CommitBuffer(bulkInsertBuffer);
                        bulkInsertBuffer.Clear();
                    }
                    bulkInsertBuffer.Add(nextItem);
                }
            };
            List<Task> parseTasks = new List<Task>(bulkInsertConcurrency);
            for (int i = 0; i < bulkInsertConcurrency; i++)
            {
                parseTasks.Add(Task.Factory.StartNew(parseAction));
            }
            // wait before exiting
            loadTask.Wait();
            Task.WaitAll(parseTasks.ToArray());
        }
