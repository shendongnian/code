    public class Program
    {
        static void Main(string[] args)
        {
            int sn = 123456782;
            int[] Digits;
            int AddedResult = 0;
            string s = sn.ToString();
            string sa = s.Substring(s.Length - 1, 1);
            int checkDigit = Convert.ToInt32(sn.ToString().Substring(s.Length - 1, 1)); //get the last digit.
            if (IsValidLength(sn))
            {
                sn = RemoveLastDigit(sn);
                Digits = ExtractEvenDigits(sn);
                Digits = DoubleDigits(Digits);
                AddedResult = AddedEvenDigits(Digits);
                AddedResult += AddOddDigits(sn);
                if (IsValidSN(AddedResult, checkDigit))
                {
                    Console.WriteLine("The number is valid");
                }
                else
                {
                    Console.WriteLine("The Number is not valid");
                }
            }
            else
            {
                Console.WriteLine("NotValidLength");
            }
            Console.Read();
            
        }
        public static bool IsValidSN(int AddedResult, int checkDigit)
        {
            return ((AddedResult % 10 == 0 && checkDigit == 0) || IsValidDifference(AddedResult, checkDigit));
            
        }
        public static bool IsValidDifference(int AddedResult, int checkDigit)
        {
            int nextHighestTens = AddedResult;
            while (nextHighestTens % 10 != 0)
            {
                nextHighestTens++;
            }
            return (nextHighestTens - AddedResult == checkDigit);
        }
        public static int AddOddDigits(int sn)
        {
            string s = sn.ToString();
            int i = 1;
            int addedResult = 0;
            foreach (char c in s)
            {
                if (i % 2 != 0)
                {
                    addedResult += Convert.ToInt32(c);
                }
                i++;
            }
            return addedResult;
        }
        public static int AddedEvenDigits(int[] Digits)
        {
            int addedEvenDigits = 0;
            string s = "";
            for (int i = 0; i < Digits.Length; i++) //extract each digit. For example 12 is extracted as 1 and 2
            {
                s += Digits[i].ToString();
            }
            for (int i = 0; i < s.Length; i++) //now add all extracted digits
            {
                addedEvenDigits += Convert.ToInt32(s[i]);
            }
            return addedEvenDigits;
        }
        public static int[] DoubleDigits(int[] Digits)
        {
            int[] doubledDigits = new int[Digits.Count()];
            for (int i = 0; i < Digits.Length; i++)
            {
                doubledDigits[i] = Digits[i] * 2;
            }
            return doubledDigits;
        }
        public static int[] ExtractEvenDigits(int sn)
        {
            int[] EvenDigits = new int[4];
            string s = sn.ToString();
            int i = 1;
            int j = 0;
            foreach (char c in s)
            {
                if (i % 2 == 0)
                {
                    
                    EvenDigits[j] = Convert.ToInt32(c);
                    j++;
                }
                i++;
            }
            return EvenDigits;
        }
        public static int RemoveLastDigit(int sn)
        {
            string s = sn.ToString();
            s.Remove(s.Length-1,1);
            return (Convert.ToInt32(s));
        }
        public static bool IsValidLength(int sn)
        {
            return (sn > 9999999 && sn < 1000000000);
                                       //123456782
        }
    }
