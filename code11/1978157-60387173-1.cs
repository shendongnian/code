     void CompareA_With_C()
                {
                    for (int i = 0; i < listC.Count; i++)
                    {
                        for (int j = 0; j < listA.Count; j++)
                        {
                            string a = listA[j].pName;
                            string c = listC[i].pName;
    
                            if (string.Equals(a, c))
                            {
                                listA[j].pPrice = listC[i].pPrice;
                            }
                        }
                    }
                    for (int i = 0; i < listA.Count; i++)
                    {
                        for (int j = 0; j < listC.Count; j++)
                        {
                            string a = listA[i].pName;
                            string c = listC[j].pName;
    
                            if (string.Equals(a, c))
                            {
                                break;
                            }
                            else if (j == (listC.Count - 1))
                            {
                                listA[i].pName = "No Product";
                                listB[i] = 0.0f;
                            }
                        }
                    }
                }
