        static void Main(string[] args)
        {
            // Read in floats from input file
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
            var floats = new List<float>();
            foreach (var l in lines)
            {
                if (float.TryParse(l, out var result))
                {
                    floats.Add(result);
                }
            }
            var array = floats.OrderBy(f => f).ToArray();
            float key = -2.4439f;
            Search(array, key);
        }
        public static void Search(float[] array, float key)
        {
            int min = 0;
            int max = array.Length - 1;
            int mid = 0;
            do
            {
                mid = (min + max) / 2;
                if (key > array[mid])
                {
                    min = mid + 1;
                }
                if (key < array[mid])
                {
                    max = mid - 1;
                }
                Console.WriteLine($"Checking {array[mid]}");
                if (key == array[mid])
                {
                    Console.WriteLine($"The item, {key} was found at index {mid} of the array");
                    break;
                }
            } while (min <= max);
        }
