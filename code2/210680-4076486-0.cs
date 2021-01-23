    char[] validChars = Enumerable.Range(0, 26).Select(i => (char)('A' + i)).ToArray();
    
            int n = 30;
            int pointer = 0;
            int pointerSec = 0;
            int Deg = 0;
            string prefix = string.Empty;
            string prefixMore = string.Empty;
            List<string> result = new List<string>();
    
            while (n > 0)
            {
                result.AddRange(validChars.Skip(pointer).Select(ch => prefix + ch).Take(n));
                if (pointer == 26)
                { 
                pointer = -1;
                Deg += 1;
                prefixMore = "" + validChars[pointerSec];
                pointerSec++;
                n++;
                }
                else
                {
                    if (Deg == 0)
                    {
                        prefix = "" + validChars[pointer];
                    }
                    else { prefix = prefixMore + validChars[pointer]; }
                }
                n = n - 1;
                pointer++;
            }
