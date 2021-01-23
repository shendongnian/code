        private void ProcessQueue()
        {
            do
            {
                    try
                    {
                        Itme job = null;
                        lock (Queue)
                        {
                            if (Queue.Count != 0)
                            {
                                job = Queue.First();
                                Queue.Remove(job);
                            }
                        }
                        if (job != null)
                        {
                            Execute(job);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.FatalException("An error has occurred while processing queued job.", e);
                    }
                
            } while (Queue.Count != 0);
            Logger.Trace("Finished processing jobs in the queue.");
            return;
        }
