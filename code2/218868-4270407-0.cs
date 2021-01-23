        public static IEnumerable<int> ToDigitEnumerable(this int number)
        {
            IList<int> digits = new List<int>();
            
            while(number > 0)
            {
                digits.Add(number%10);
                number = number/10;
            }
            //digits are currently backwards, reverse the order
            return digits.Reverse();
        }
        public static bool IsCanadianSocialInsuranceNumber(int number)
        {
            var digits = number.ToDigitEnumerable();
            if (digits.Count() != 9) return false;
            //The left side of the addition is adding all even indexes (except the last digit).
            //We are adding even indexes since .NET uses base 0 for indexes
            //The right side of the addition, multiplies the odd index's value by 2, then breaks each result into
            //individual digits, then adds them together
            var total = digits.Where((value, index) => index%2 == 0 && index != 8).Sum()
                        + digits.Where((value, index) => index%2 != 0).Select(v => v*2)
                              .SelectMany(v => v.ToDigitEnumerable()).Sum();
            //The final modulous 10 operator is to handle the scenarios where the total
            //is divisble by 10, in those cases, the check sum should be 0, not 10
            var checkDigit = (10 - (total%10)) % 10;
            return digits.Last() == checkDigit;
        }
