    /// <summary>
        /// Converts Decimals into Fractions.
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <returns>Fraction in string type</returns>
        public string DecimalToFraction(double value)
        {
            string result;
            double numerator, realValue = value;
            int num, den, decimals, length;
            num = (int)value;
            value = value - num;
            value = Math.Round(value, 5);
            length = value.ToString().Length;
            decimals = length - 2;
            numerator = value;
            for (int i = 0; i < decimals; i++)
            {
                if (realValue < 1)
                {
                    numerator = numerator * 10;
                }
                else
                {
                    realValue = realValue * 10;
                    numerator = realValue;
                }
            }
            den = length - 2;
            string ten = "1";
            for (int i = 0; i < den; i++)
            {
                ten = ten + "0";
            }
            den = int.Parse(ten);
            num = (int)numerator;
            result = SimplifiedFractions(num, den);
            return result;
        }
        /// <summary>
        /// Converts Fractions into Simplest form.
        /// </summary>
        /// <param name="num">Numerator</param>
        /// <param name="den">Denominator</param>
        /// <returns>Simplest Fractions in string type</returns>
        string SimplifiedFractions(int num, int den)
        {
            int remNum, remDen, counter;
            if (num > den)
            {
                counter = den;
            }
            else
            {
                counter = num;
            }
            for (int i = 2; i <= counter; i++)
            {
                remNum = num % i;
                if (remNum == 0)
                {
                    remDen = den % i;
                    if (remDen == 0)
                    {
                        num = num / i;
                        den = den / i;
                        i--;
                    }
                }
            }
            return num.ToString() + "/" + den.ToString();
        }
    }
