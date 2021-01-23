            String[] inputNumbers = inputNumbersCSV.Split(',');
            int sumOfNum = 0;
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                sumOfNum = sumOfNum + int.Parse(inputNumbers[i]); 
            }
            return sumOfNum;
        }
