     public string Info(string guess, string actual)
            {
                int correctNumbers = 0;
                string correctChars = "";
    
                foreach (var char_ in guess)
                {
                    if (actual.Contains<char>(char_))
                    {
                        correctNumbers++;
                        correctChars += char_.ToString();
                    }
                }
    
                return $"{correctNumbers}({correctChars})";
            }
