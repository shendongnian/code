    string[] lsData = pData.Split(' ');
                string[] lsData1 = new string[18];
                int newArrayData = 0;
                int spaceCounter = 0;
                for (int i = 0; i < lsData.Length; i++)
                {
                    if (lsData[i] != "")
                    {
                        lsData1[newArrayData] = lsData[i];
                        newArrayData++;
                        spaceCounter = 0;
                    }
                    else
                    {
                        spaceCounter++;
                    }
                    if (spaceCounter >= 10)
                    {
                        lsData1[newArrayData] = "";
                        newArrayData++;
                        spaceCounter = 0;
                    }
                }
