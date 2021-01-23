    class Program
    {
        static void Main(string[] args)
        {
            var src = new byte[] { 1, 2, 3, 4, 5 };
            var tag = new byte[] { 3, 4 };
            var index = FindIndexOfSeq(src, tag);
            Console.WriteLine(index);
            Console.ReadLine();
        }
        static int FindIndexOfSeq<T>(T[] src, T[] seq)
        {
            int index = -1;
            for (int i = 0; i < src.Length - seq.Length + 1; i++)
            {
                bool foundSeq = true;
                for (int j = 0; j < seq.Length; j++)
                {
                    foundSeq = foundSeq && src[i + j].Equals(seq[j]);
                }
                if (foundSeq)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
