       if (vatNo.Length == 9)
                {
                    int calcValue = 0;
                    int index = 0;
                    int checkDigit = Convert.ToInt32(vatNo.Substring(7, 2));
                    
                    for (int ordinate = 8; ordinate > 1; ordinate--)
                    {
                        calcValue += Convert.ToInt32((vatNo.Substring(index, 1))) * ordinate;
                        index++;
                    }
                    while (calcValue > 0)
                    {
                        calcValue -= 97;
                    }
                    if ((calcValue * -1) != checkDigit)
                    {
                        Error
                    }
                    
                }
