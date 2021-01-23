    string myString = "|1 Test 1|This my first line.|2 Test 2|This is my second line";
                string[] mainArray = myString.Split('|');
                String str = "";
                List<string> firstList = new List<string>();
                List<string> secondList = new List<string>();
                for (int i = 1; i < mainArray.Length; i++)
                {
                    if ((i % 2) == 0)
                    {
                        str += "\n|" + mainArray[i];
                        firstList.Add(mainArray[i]);
                    }
                    else
                    {
                        str += "\n|" + mainArray[i] + "|";
                        secondList.Add(mainArray[i]);
                    }
                }
