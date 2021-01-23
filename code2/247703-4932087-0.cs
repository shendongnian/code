       List<int> list = new List<int>();
       for (int j = 0; j < arrayA.Length; j++)
            {
                for (int k = 0; k < arrayB.Length; k++)
                {
                    if (arrayA[j] == arrayB[k])
                    {               
                        list.Add(arrayB[k]); // HERE !!
                     
                    }
                }
            }
