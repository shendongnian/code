    namespace System
    {
        public static class StringExts
        {
            public static IEnumerable<string> ReverseCut(this string txt, int cutSize)
            {
                int first = txt.Length % cutSize;
                int taken = 0;
    
                string nextResult = new String(txt.Skip(taken).Take(first).ToArray());
                taken += first;
                do
                {
                    if (nextResult.Length > 0)
                        yield return nextResult;
    
                    nextResult = new String(txt.Skip(taken).Take(cutSize).ToArray());
                    taken += cutSize;
                } while (nextResult.Length == cutSize);
    
            }
        }
    }
