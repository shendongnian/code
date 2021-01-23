            var size = 10;
            var capacity = 2;
            var target = 5;
            var repeat = 10000;
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
            int knapsack = -1;
            
            Stopwatch sw = new Stopwatch();            
            sw.Start();
            for (int r = 0; r < repeat; r++)
            {
                // pruning code. I realize I have overhead of list conversion.
                // but I'm also not sorting a collection of two items,
                // so I think it's about fair
                //var list = new List<float>(weights); //
                //list.Sort();
                //weights = list.ToArray();
                for (int i = 0; i < (int)Math.Pow(2, size); i++)
                {
                    var splitOut = Convert.ToString(i, 2).PadLeft(10, '0');
                    var total = 0d;
                    var weight = 0d;
                    for (int j = 0; j < size; j++)
                    {
                        if (splitOut[j] == '1')
                        {
                            total += items[j];
                            weight += weights[j];
                            if (total > target || weight > capacity)
                            {
                                break;
                            }
                        }
                    }
                    // more pruning code
                    //if (total == target && weight <= capacity)
                    //{
                    //    knapsack = i;
                    //    break;
                    //}
                }
            }
            sw.Stop();
            sw.Elapsed.ToString();
