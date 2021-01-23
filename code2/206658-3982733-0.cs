            Timer t = new Timer(100);
            t.Elapsed += (sender, e) =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // your loop
                    }
                };
            t.Start();
