        public static int Search(string word, List<string> stringList)
        {
            string wordCopy = word.ToLower();
            List<string> stringListCopy = new List<string>();
            stringList.ForEach(s => stringListCopy.Add(s.ToLower()));
            stringListCopy.Sort();
            int position = -1;
            int count = stringListCopy.Count;
            if (count > 0)
            {
                int min = 0;
                int max = count - 1;
                int middle = (max - min) / 2;
                int comparisonStatus = 0;
                do
                {
                    comparisonStatus = string.Compare(wordCopy, stringListCopy[middle]);
                    if (comparisonStatus == 0)
                    {
                        position = middle;
                        break;
                    }
                    else if (comparisonStatus < 0)
                    {
                        max = middle - 1;
                    }
                    else
                    {
                        min = middle + 1;
                    }
                    middle = min + (max - min) / 2;
                } while (min < max);
            }
            return position;
        }
