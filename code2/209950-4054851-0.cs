        public static void WriteSlow(string txt) {
            foreach (char ch in txt) {
                Console.Write(ch);
                System.Threading.Thread.Sleep(50);
            }
        }
