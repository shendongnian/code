         public static Pair[]  GetIndex(int[] inputArray, int[] query)
          {
            Pair[] pairList = new Pair[query.Length]; 
            int pairIndex = 0;
            foreach (int i in query)
            {
                Pair pair = new Pair();
                int index = 0;
                pair.Position = new List<int>();
                foreach (int j in inputArray)
                {                    
                    if (i == j)
                    {
                        pair.Position.Add(index);
                    }
                    index++;
                }
                pair.Number = i;
                pairList[pairIndex] = pair;
                pairIndex++;
            }
            return pairList;
        }
