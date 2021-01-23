        public static List<int> Test2(List<int> arrayInput)
        {
            for (int i = 0; i < arrayInput.Count - 2; i++)
            {
                if (arrayInput[i + 2] == arrayInput[i + 1] + 1
                && arrayInput[i + 2] == arrayInput[i] + 2)
                {
                    arrayInput.RemoveAt(i + 2);
                    arrayInput.RemoveAt(i);
                    i--;
                }
            }
            return arrayInput;
        }
