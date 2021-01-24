        {
            string[] parts = Regex.Split(line, "[" + punctuation + "]+");
            int max = 0;
            string temp = "";
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length > max) //If Longest Word
                {
                    if ((parts[i].Length + 1) / 2 <= NumberOfDigits(parts[i])) // If atleast half of numbers are digits
                    {
                        temp = parts[i];
                        max = parts[i].Length;
                    }
                }
            }
            Match withPunctuation = Regex.Match(line, temp + "[" + punctuation + "]+"); // matches line with word and punctuation
            return withPunctuation.ToString();
        }
