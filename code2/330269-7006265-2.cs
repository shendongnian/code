    public class Mod11
    {
        public static string AddCheckDigit(string number)
        {
            int Sum = 0;
            for (int i = number.Length - 1, Multiplier = 2; i >= 0; i--)
            {
                Sum += (int)char.GetNumericValue(number[i]) * Multiplier;
                if (++Multiplier == 8) Multiplier = 2;
            }
            string Validator = (11 - (Sum % 11)).ToString();
            if (Validator == "11") Validator = "0";
            else if (Validator == "10") Validator = "X";
            return number + Validator;
        }
    }
