            var inputArr = new string[]{"mapa","art","tra","pam","why"};
            var outputList = new List<string>();
            for (int i = 0; i < inputArr.Length; i++)
            {
                for (int j = i+1; j<inputArr.Length ; j++)
                {                    
                    char[] temp1 = inputArr[i].ToLower().ToCharArray();
                    char[] temp2 = inputArr[j].ToLower().ToCharArray();
                    if (temp1.Length != temp2.Length)
                        continue;
                    else
                    {
                        bool isAnnograms = true;
                        for (int k1 = 0, k2=temp1.Length-1; k1 < temp1.Length; k1++,k2--)
                        {
                            if (temp1[k1] == temp2[k2])
                                continue;
                            else
                                isAnnograms = false;
                        }
                        if (isAnnograms)
                        {
                            outputList.Add(new string(temp1));
                            outputList.Add(new string(temp2));
                            isAnnograms = false;
                        }
                    }
                }
            }
