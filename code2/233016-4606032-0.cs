        private static int GetRandomNumber(string existingNumbers, int max)
        {
            string[] existingNumbersArray = existingNumbers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> existingNumbersList = new List<string>();
            foreach (string number in existingNumbersArray)
            {
                existingNumbersList.Add(number.Trim());
            }
            while (true)
            {
                Random rnd = new Random();
                int value = rnd.Next(max);
                if (!existingNumbersList.Contains(value.ToString()))
                {
                    return value;
                }
            }
        }
