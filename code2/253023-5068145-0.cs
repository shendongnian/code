         private decimal RemoveTrailingZeros(decimal Dec)
        {
            string decString = Dec.ToString();
            if (decString.Contains("."))
            {
                string[] decHalves = decString.Split('.');
                int placeholder = 0, LoopIndex = 0;
                foreach (char chr in decHalves[1])
                {
                    LoopIndex++;
                    if (chr != '0')
                        placeholder = LoopIndex;
                }
                decHalves[1] = decHalves[1].Remove(placeholder);
                Dec = decimal.Parse(decHalves[0] + "." + decHalves[1]);
            }
            return Dec;
        }
