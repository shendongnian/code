    private static void Main() {
            Dictionary<int, float> dct = new Dictionary<int, float> {
                {1,8.65f },
                {2,7.65f },
                { 3, 8.89f },
                { 4, 8.90f },
                { 5, 7.95f }
            };
            DictionaryUtils utils = new DictionaryUtils(dct);
            Console.WriteLine($"min {utils.GetMinValue(1, 4)}\nmax {utils.GetMaxValue(1, 4)}");
            //prints -->  min 7.65 
            //            max 8.9
            
            Console.ReadLine();
        }
