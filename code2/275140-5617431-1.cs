    using System;
    using System.Globalization;
    
    /// <summary>
    /// Si prefixed string conversion class
    /// </summary>
    public static class SIPrefixedString
    {
        /// <summary>
        /// converts the value into a string with SI prefix
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>si prefixed string</returns>
        public static string ToSIPrefixedString(this double value)
        {
            string stringValue = value.ToString("#E+00", CultureInfo.InvariantCulture);
            string[] stringValueParts = stringValue.Split("E".ToCharArray());
            int mantissa = Convert.ToInt32(stringValueParts[0], CultureInfo.InvariantCulture);
            int exponent = Convert.ToInt32(stringValueParts[1], CultureInfo.InvariantCulture);
            while (exponent % 3 != 0)
            {
                mantissa *= 10;
                exponent -= 1;
            }
    
            string prefixedValue = mantissa.ToString(CultureInfo.InvariantCulture);
            switch (exponent)
            {
                case 24:
                    prefixedValue += "Y";
                    break;
                case 21:
                    prefixedValue += "Z";
                    break;
                case 18:
                    prefixedValue += "E";
                    break;
                case 15:
                    prefixedValue += "P";
                    break;
                case 12:
                    prefixedValue += "T";
                    break;
                case 9:
                    prefixedValue += "G";
                    break;
                case 6:
                    prefixedValue += "M";
                    break;
                case 3:
                    prefixedValue += "k";
                    break;
                case 0:
                    break;
                case -3:
                    prefixedValue += "m";
                    break;
                case -6:
                    prefixedValue += "u";
                    break;
                case -9:
                    prefixedValue += "n";
                    break;
                case -12:
                    prefixedValue += "p";
                    break;
                case -15:
                    prefixedValue += "f";
                    break;
                case -18:
                    prefixedValue += "a";
                    break;
                case -21:
                    prefixedValue += "z";
                    break;
                case -24:
                    prefixedValue += "y";
                    break;
                default:
                    prefixedValue = "invalid";
                    break;
            }
    
            return prefixedValue;
        }
    
        /// <summary>
        /// returns the double value for the si prefixed string
        /// </summary>
        /// <param name="prefixedValue">The prefixed value.</param>
        /// <returns>double value</returns>
        public static double FromSIPrefixedString(this string prefixedValue)
        {
            string scientificNotationValue = prefixedValue;
    
            if (scientificNotationValue.Contains("E+") == false && scientificNotationValue.Contains("E-") == false)
            {
                scientificNotationValue = scientificNotationValue
                    .Replace("Y", "E+24")
                    .Replace("Z", "E+21")
                    .Replace("E", "E+18")
                    .Replace("P", "E+15")
                    .Replace("T", "E+12")
                    .Replace("G", "E+09")
                    .Replace("M", "E+06")
                    .Replace("k", "E+03")
                    .Replace("m", "E-03")
                    .Replace("u", "E-06")
                    .Replace("n", "E-09")
                    .Replace("p", "E-12")
                    .Replace("f", "E-15")
                    .Replace("a", "E-18")
                    .Replace("z", "E-21")
                    .Replace("y", "E-24");
            }
    
            return Convert.ToDouble(scientificNotationValue, CultureInfo.InvariantCulture);
        }
