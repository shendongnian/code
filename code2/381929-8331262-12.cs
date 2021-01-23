        /// <summary>
        /// This method uses a shuffle based algorithm to create a two-dimensional array of [height, width] 
        /// with exactly locationsToFind locations set to 1. 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="locationsToFind"></param>
        /// <returns></returns>
        public int[,] ShuffleImplementation(int height, int width, int locationsToFind)
        {
            locationsToFind = LimitLocationsToFindToMaxLocations(height, width, locationsToFind);
            // Create a 1 dimensional array large enough to contain all our values. 
            var array = new int[height * width];
            // Set locationToFind locations to 1. 
            for (int location = 0; location < locationsToFind; location++)
                array[location] = 1;
            // Shuffle our array.
            Shuffle(array);
            // Now let's create our two-dimensional array.
            var map = new int[height, width];
            int index = 0;
            // Expand our one-dimensional array into a two-dimensional one. 
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[y, x] = array[index];
                    index++;
                }
            }
            return map;
        }
        /// <summary>
        /// Shuffles a one-dimensional array using the Fisher-Yates shuffle. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Shuffle<T>(T[] array)
        {
            var random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int n = random.Next(i + 1);
                Swap(ref array[i], ref array[n]);
            }
        }
        /// <summary>
        /// Swaps two values around. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueA"></param>
        /// <param name="valueB"></param>
        public static void Swap<T>(ref T valueA, ref T valueB)
        {
            T tempValue = valueA;
            valueA = valueB;
            valueB = tempValue;
        }
