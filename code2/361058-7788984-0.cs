        void Main()
        {
            const int inputCollectionBufferSize = 1024;
            const int bulkInsertBufferCapacity = 100;
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
            Task parseTask = Task.Factory.StartNew(() =>
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
            });
            // wait before exiting
            Task.WaitAll(loadTask, parseTask);
        }
