        static void drawIsoscelesTraiangle(char repeatChar, int peak, int current)
        {
            for (int i = 0; i < peak; i++)
            {
                Console.WriteLine(new String(repeatChar, current++));
            }
            for (int i = current; i > 0; i--)
            {
                Console.WriteLine(new String(repeatChar, current--));
            }
        }
