                    this.Actions.Enqueue(delegate
                    {
                        try
                        {
                            action();
                            Console.WriteLine("Actioned");
                        }
                        catch
                        {
                            Console.WriteLine("Exception thrown by action");
                            throw;
                        }
                        finally
                        {
                            semaphore.Release();
                            Console.WriteLine("Released");
                        }
                    });
