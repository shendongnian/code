        private static int[] GetValues()
        {
            string inValue;
            int[] score = new int[5];
            int total = 0;
            for (int i = 0; i < score.Length; i++)
            {
                Console.Write("Enter Value {0}: ", i + 1);
                inValue = Console.ReadLine();
                score[i] = Convert.ToInt32(inValue);
            }
            return score;
        }
