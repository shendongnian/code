        // A separate static function
        private static IEnumerable<IEnumerable<T>> BreakIntoBlocks<T>(T[] source, int blockSize)
        {
            for (int i = 0; i < source.Length; i += blockSize)
            {
                yield return source.Skip(i).Take(blockSize);
            }
        }
        // And in your code
        string[] lines = new string[1000000];
        foreach(IEnumerable<string> stringBlock in BreakIntoBlocks(lines, 100))
        {
                // stringblock is a block of 100 elements
                // Here is where you put the code that processes each separate group
        }
