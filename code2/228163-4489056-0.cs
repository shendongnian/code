                string str1 = "SeveralWordsString";
                string newstring = "";
                for (int i = 0; i < str1.Length; i++)
                {
                    if (char.IsUpper(str1[i]))
                        newstring += " ";                    
                    newstring += str1[i].ToString();
                }
