            var task = new Task(() =>
                                    {
                                        var task1 = new Task(() =>
                                                                {
                                                                });
                                        task1.Start();
                                        if (task1.Wait(10000))
                                        {
                                            Console.WriteLine("yes");
                                        }
                                        else
                                        {
                                            Console.WriteLine("no");
                                        }
                                    });
            task.Start();
            if (task.Wait(10000))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
