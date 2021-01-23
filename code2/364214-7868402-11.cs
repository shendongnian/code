    class Program
    {
        class ArraySegmentComparer : IEqualityComparer<ArraySegment<char>>
        {
            public bool Equals(ArraySegment<char> x, ArraySegment<char> y)
            {
                if (x.Count != y.Count)
                {
                    return false;
                }
                int end = x.Offset + x.Count;
                for (int i = x.Offset, j = y.Offset; i < end; i++, j++)
                {
                    if (!x.Array[i].ToString().Equals(y.Array[j].ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }
            public override int GetHashCode(ArraySegment<char> obj)
            {
                unchecked
                {
                    int hash = 17;
                    int end = obj.Offset + obj.Count;
                    int i;
                    for (i = obj.Offset; i < end; i++)
                    {
                        hash *= 23;
                        hash += Char.ToUpperInvariant(obj.Array[i]);
                    }
                    return hash;
                }
            }
        }
        static void Main()
        {
            var rx = new Regex(@"\b\w+\b", RegexOptions.Compiled);
            var sampleText = @"For my custom made chat screen i am using the code below for checking censored words. But i wonder can this code performance improved. Thank you.
    if (srMessageTemp.IndexOf("" censored1 "") != -1)
    return;
    if (srMessageTemp.IndexOf("" censored2 "") != -1)
    return;
    if (srMessageTemp.IndexOf("" censored3 "") != -1)
    return;
    C# 4.0 . actually list is a lot more long but i don't put here as it goes away.
    And now some accented letters àèéìòù and now some letters with unicode combinable diacritics àèéìòù";
            //sampleText += sampleText;
            //sampleText += sampleText;
            //sampleText += sampleText;
            //sampleText += sampleText;
            //sampleText += sampleText;
            //sampleText += sampleText;
            //sampleText += sampleText;
            HashSet<string> prohibitedWords = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "For", "custom", "combinable", "away" };
            Stopwatch sw1 = Stopwatch.StartNew();
            var words = rx.Matches(sampleText);
            foreach (Match word in words)
            {
                string str = word.Value;
                if (prohibitedWords.Contains(str))
                {
                    Console.Write(str);
                    Console.Write(" ");
                }
                else
                {
                    //Console.WriteLine(word);
                }
            }
            sw1.Stop();
            Console.WriteLine();
            Console.WriteLine();
            HashSet<ArraySegment<char>> prohibitedWords2 = new HashSet<ArraySegment<char>>(
                prohibitedWords.Select(p => new ArraySegment<char>(p.ToCharArray())),
                new ArraySegmentComparer());
            var sampleText2 = sampleText.ToCharArray();
            Stopwatch sw2 = Stopwatch.StartNew();
            int startWord = -1;
            for (int i = 0; i < sampleText2.Length; i++)
            {
                if (Char.IsLetter(sampleText2[i]) || Char.IsDigit(sampleText2[i]))
                {
                    if (startWord == -1)
                    {
                        startWord = i;
                    }
                }
                else
                {
                    if (startWord != -1)
                    {
                        int length = i - startWord;
                        
                        if (length != 0)
                        {
                            var wordSegment = new ArraySegment<char>(sampleText2, startWord, length);
                            if (prohibitedWords2.Contains(wordSegment))
                            {
                                Console.Write(sampleText2, startWord, length);
                                Console.Write(" ");
                            }
                            else
                            {
                                //Console.WriteLine(sampleText2, startWord, length);
                            }
                        }
                        startWord = -1;
                    }
                }
            }
            if (startWord != -1)
            {
                int length = sampleText2.Length - startWord;
                if (length != 0)
                {
                    var wordSegment = new ArraySegment<char>(sampleText2, startWord, length);
                    if (prohibitedWords2.Contains(wordSegment))
                    {
                        Console.Write(sampleText2, startWord, length);
                        Console.Write(" ");
                    }
                    else
                    {
                        //Console.WriteLine(sampleText2, startWord, length);
                    }
                }
            }
            sw2.Stop();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(sw1.ElapsedTicks);
            Console.WriteLine(sw2.ElapsedTicks);
        }
    }
