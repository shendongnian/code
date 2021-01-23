        public class NumberConverter
        {
            public const string HEX = "0123456789abcdef";
            public const string Bigger = "0123456789abcdefghihjklmnopqrstuvqyz";
            private int _numericBase;
            private string _base;
            public NumberConverter(string numberBase)
            {
                _base = numberBase;
                _numericBase = numberBase.Length;
            }
            public string ToString(int number)
            {
                var remainder = number % _numericBase;
                var div = number / _numericBase;
                string tmp = "";
                while (div > 0)
                {
                    tmp = _base[remainder] + tmp;
                    remainder = div % _numericBase;
                    div = div / _numericBase;
                }
                tmp = _base[remainder] + tmp;
                return tmp;
            }
            public int ToNumber(string numberString)
            {
                int index = numberString.Length - 1;
                int value = 0;
                int power = 0;
                while (index >= 0)
                {
                    char currentChar = numberString[index];
                    var currentValue = _base.IndexOf(currentChar);
                    value += currentValue * (int)Math.Pow(_numericBase, power);
                    power++;
                    --index;
                }
                return value;
            }
        }
       
        public static void Main()
        {
            var converter = new NumberConverter(NumberConverter.Bigger);
            int userId = 755757;
            var numberString = converter.ToString(userId); // prints g759
            var value = converter.ToNumber(numberString);
        }
