            var size = 10;
            var capacity = 2;
            var target = 5;
            var repeat = 10000;
            // Generate items
            float[] items = new float[size];
            float[] weights = new float[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                items[i] = (float)rand.NextDouble();
                weights[i] = (float)rand.NextDouble();
                if (rand.Next(2) == 1)
                {
                    weights[i] *= -1;
                }
            }
            // solution
            int bestPosition= -1;
            
            Stopwatch sw = new Stopwatch();            
            sw.Start();
            // for perf testing
            //for (int r = 0; r < repeat; r++)
            {
                var bestValue = 0d;
                // solve
                for (int i = 0; i < permutations; i++)
                {
                    var total = 0d;
                    var weight = 0d;
                    for (int j = 0; j < size; j++)
                    {
                        if (((i >> j) & 1) == 1)
                        {
                            total += items[j];
                            weight += weights[j];
                        }
                    }
                    if (weight <= capacity && total > bestValue)
                    {
                        bestPosition = i;
                        bestValue = total;
                    }
                }
            }
            sw.Stop();
            sw.Elapsed.ToString();
