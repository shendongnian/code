    static void Print(int left, int top, params string[] lines)
    {
        foreach (string line in lines)
        {
            string[] words = line.Trim().Split(new char[] { ' ' });
            foreach (string word in words)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(word);
                top++;
            }
        }
    }
