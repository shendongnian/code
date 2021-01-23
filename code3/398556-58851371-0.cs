        public static int CountWords(this string line)
        {
            var wordCount = 0;
            for (var i = 0; i < line.Length; i++)
                if (line[i] == ' ' || i == line.Length - 1)
                    wordCount++;
            return wordCount;
        }
    }
