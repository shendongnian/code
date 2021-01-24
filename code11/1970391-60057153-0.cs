             while (true)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(
                        "cancelled on the token", token);
                }
                Console.WriteLine(txt);
                Thread.Sleep(500);
            }
