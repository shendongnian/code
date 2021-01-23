       static void PrintSmallestLargest(int[] arr)
        {
            if (arr.Length > 0)
            {
                int small = arr[0];
                int large = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (large < arr[i])
                    {
                        int tmp = large;
                        large = arr[i];
                        arr[i] = large;
                    }
                    if (small > arr[i])
                    {
                        int tmp = small;
                        small = arr[i];
                        arr[i] = small;
                    }
                }
                Console.WriteLine("Smallest is {0}", small);
                Console.WriteLine("Largest is {0}", large);
            }
        }
