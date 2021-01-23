        public static string CombineNumbers(string number1, string number2)
        {
            int length = number1.Length > number2.Length ? number1.Length : number2.Length;
            string returnValue = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int n1 = i >= number1.Length ? 0 : int.Parse(number1.Substring(i,1));
                int n2 = i >= number2.Length ? 0 : int.Parse(number2.Substring(i,1));
                int sum = n1 + n2;
                returnValue += sum < 10 ? sum : sum - 10;
            }
            return returnValue;
        }
