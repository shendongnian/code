    for (int Indices = 0; Indices < Details.Items.Count; Indices++)
                            {
                                FileName = Details.Items[Indices].SubItems[7].Text;
                                Stop.Start();
                                    Thread Generating = new Thread(() => new Methods.Generate(FileName, FileHost, Sender as BackgroundWorker))
                                {
                                    IsBackground = true
                                };
                                Generating.Start();
                                Generating.Join();
                            }
