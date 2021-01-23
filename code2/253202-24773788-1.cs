    class CharCount
    {
        public void CountCharacter()
        {
            int n;
            Console.WriteLine("enter the no. of elements: ");
            n = Convert.ToInt32(Console.ReadLine());
            char[] chararr = new char[n];
            Console.WriteLine("enter the elements in array: ");
            for (int i = 0; i < n; i++)
            {
                chararr[i] = Convert.ToChar(Console.ReadLine());
            }
            Dictionary<char, int> count = chararr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            foreach(KeyValuePair<char, int> key in count)
            {
                Console.WriteLine("Occurrence of {0}: {1}",key.Key,key.Value);
            }
            Console.ReadLine();
        }
    }
