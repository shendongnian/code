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
