    // Specify a maximum of 1000 items in the collection so that we don't
    // run out of memory if we get data faster than we can commit it.
    // Add() will wait if it is full.
    BlockingCollection<ComplexDataSet> commits =
        new BlockingCollection<ComplexDataSet>(1000);
    Task consumer = Task.Factory.StartNew(() =>
        {
            // This is the consumer.  It processes the
            // "commits" queue until it signals completion.
            while(!commits.IsCompleted)
            {
                ComplexDataSet cds;
                // Timeout of -1 will wait for an item or IsCompleted == true.
                if(commits.TryTake(out cds, -1))
                {
                    // Got at least one item, write it.
                    db.Write(cds);
                    // Continue dequeuing until the queue is empty, where it will
                    // timeout instantly and return false, or until we've dequeued
                    // 100 items.
                            
                    for(int i = 1; i < 100 && commits.TryTake(out cds, 0); ++i)
                    {
                        db.Write(cds);
                    }
                    // Now that we're waiting for more items or have dequeued 100
                    // of them, commit.  More can be continue to be added to the
                    // queue by other threads while this commit is processing.
                    db.Commit();
                }
            }
        });
    try
    {
        // This is the producer.
        Parallel.For(0, 1000000, i =>
            {
                ComplexDataSet data = GenerateData(i);
                commits.Add(data);
            });
    }
    finally // put in a finally to ensure the task closes down.
    {
        commits.CompleteAdding(); // set commits.IsFinished = true.
        consumer.Wait(); // wait for task to finish committing all the items.
    }
