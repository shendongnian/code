cs
static void ExampleOne()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //Assuming the values in the array are random.
            int[,] arr = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (arr[i, j] < 5 || (arr[i, j] > 10 && arr[i, j] < 20))
                    {
                        arr[i, j] = 0;
                    }
                    else
                    {
                        arr[i, j] = 1;
                    }
                }
            }
            Console.WriteLine(stopwatch.ElapsedTicks);
            stopwatch.Stop();
        }
        static void ExampleTwo()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //Assuming the values in the array are random.
            int[,] arr = new int[10, 10];
            int val;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    val = arr[i, j];
                    if (val < 5 || (val > 10 && val < 20))
                    {
                        arr[i, j] = 0;
                    }
                    else
                    {
                        arr[i, j] = 1;
                    }
                }
            }
            Console.WriteLine(stopwatch.ElapsedTicks);
            stopwatch.Stop();
        }
