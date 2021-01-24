    public static string ProcessOperations(string numbers)
    {
        string[] numberArray;
        string returnValue = string.Empty;
    
        numberArray = numbers.Split(' ');
        for (int i = 0; i < numberArray.Length - 2; i++)
        {
            if (int.TryParse(numberArray[i], out int a) &&
                int.TryParse(numberArray[i + 1], out int b) &&
                int.TryParse(numberArray[i + 2], out int c))
            {
                if (a + b == c)
                    returnValue += "addition, ";
                else if (a - b == c)
                    returnValue += "subtraction, ";
                else if (a * b == c)
                    returnValue += "multiplication, ";
                else if (a / b == c)
                    returnValue += "division, ";
            }
        }
    
        returnValue = returnValue.TrimEnd(new[] { ',', ' ' });
    
        return returnValue;
    }
