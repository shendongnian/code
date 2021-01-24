  static void Main(string[] args)
        {
            string str = "abbbcdef";
            str = str.ToLower();
            char[] arrayInput = str.ToCharArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] amounts = new int[str.Length];
            foreach (char letter in arrayInput)
            {
                for (int x = 0; x < alphabet.Length; x++)
                {
                    if (letter.ToString() == alphabet[x].ToString())
                    {
                        amounts[x]++;
                    }
                }
            }
            int numToRemove = 0;
            amounts = amounts.Where(val => val != numToRemove).ToArray();
            foreach (int amount in amounts)
            {
                Console.Write(amount + ", ");
            }
            Console.ReadKey();
        }
Hi
