        int maxlength = 12;
        string ValidChars;
        private void Dive(string prefix, int level)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                Console.WriteLine(prefix + c);
                if (level < maxlength)
                {
                    Dive(prefix + c, level);
                }
            }
        }
