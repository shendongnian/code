     if (txt1.Text.Contains('*'))
                {
                    foreach (char c in txt1.Text)
                        if (c.Equals('*'))
                            barredCharCount += 1;
                    curPosition = txt1.SelectionStart;
                    isTextReplaced = true;
                }
                txt1.Text = txt1.Text.Replace("*", string.Empty);
                if (isTextReplaced)
                {
                    txt1.Select(curPosition.Equals(0) ? 0 : curPosition - barredCharCount, 0);
                    isTextReplaced = false;
                    curPosition = barredCharCount = 0;
                    Console.Beep(); //does not work on 64 bit system
                }
