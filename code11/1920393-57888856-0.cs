                if (d == 2)
                {
                    for(int i = 0; i < n; i++)
                    {
                        int a = rand.Next(m);
                        int b = rand.Next(m);
                        servers[a < b ? a : b].Tasks++;
                    }
                }
