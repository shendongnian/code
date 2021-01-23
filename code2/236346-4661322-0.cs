        static int[] array = new int[100];
        static void UseForLoop () {
            for (int i = 0; i < array.Length; ++i) {
                Console.WriteLine(array[i]);
            }
        }
        static void UseForeachLoop () {
            foreach (int i in array) {
                Console.WriteLine(i);
            }
        }
