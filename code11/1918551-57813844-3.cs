    private static void Main() {
            Dictionary<int, float> dct = new Dictionary<int, float> {
                {1, 8.65f},
                {2, 7.65f},
                {3, 7.65f},
                {4, 8.90f},
                {5, 7.95f}
            };
            
            List<int> keysByMax = new List<int>();
            List<int> keysByMin = new List<int>();
            dct.GetKeysByValueInRange(1, 4, out keysByMin, out keysByMax);
            foreach (var item in keysByMin) {
                Console.Write($"min {item} ");
                // printst min 2 min 3
            }
            Console.WriteLine();
            foreach (var item in keysByMax) {
                Console.Write($"max {item} ");
                //prints max 4
            }
            Console.ReadLine();
        }
