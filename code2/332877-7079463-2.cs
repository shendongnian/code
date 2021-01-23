            for (var start = 0; start < words.Length - 2; start++) // at least one word
            {
                for (var end = start + 1; end < words.Length - 1; end++)
                {
                    var segment = new DelimitedArray<string>(words, start, end - start);
                    lemma = string.Join(" ", segment.GetEnumerator()); // get the word/phrase to test
                    result = this.DoTheTest(lemma);
                    
                    if (result > 0)
                    {
                        // Add the new result
                        ret = ret + result;
                        // Move the start sentinel up, mindful of the +1 that will happen at the end of the loop
                        start = start + segment.Count - 1;
                        // And instantly finish the end sentinel; we're done here.
                        end = words.Length;
                    }
                }
            }
