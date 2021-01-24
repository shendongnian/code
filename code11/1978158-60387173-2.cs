     void CompareA_With_C()
            {
                for (int i = 0; i < listA.Count; i++)
                {
                    for (int j = 0; j < listC.Count; j++)
                    {
                        string a = listA[i].pName;
                        string c = listC[j].pName;
                        if (string.Equals(a, c))
                        {
                            listA[i].pPrice = listC[j].pPrice;
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
