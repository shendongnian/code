            Parallel.ForEach(BlockingCollectionExtensions.GetConsumingPartitioneenter(_packetQ),
                             sweep => {
                               //do stuff
                               var worker = new IfftWorker();
                               Trace.WriteLine("  Thread {0} picking up a pending ifft".With(Thread.CurrentThread.ManagedThreadId));
                               worker.DoIfft(sweep);                
                             });
