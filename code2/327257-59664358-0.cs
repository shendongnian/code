    class Program
    {
        static void Main(string[] args)
        {
            List<string> cultures = new List<string> { "ca-ES", "co-FR", "cs-CZ", "cy-GB", "da-DK", "de-AT", "de-CH", "de-DE", "de-LI", "de-LU", "dsb-DE", "en-US", "en-GB" };
            var amount = -16.34M;
            foreach (var c in cultures)
            {
                var cultureInfo = CultureInfo.GetCultureInfo(c);
                var numberFormat = cultureInfo.NumberFormat;
                String formattedAmount = null;
                if (amount >= Decimal.Zero)
                {
                    String pattern = null;
                    switch (numberFormat.CurrencyPositivePattern)
                    {
                        case 0:
                            pattern = "{0}{1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 1:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "}{0}";
                            break;
                        case 2:
                            pattern = "{0} {1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 3:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "} {0}";
                            break;
                    }
                    formattedAmount = String.Format(cultureInfo, pattern, numberFormat.CurrencySymbol, amount);
                }
                else if (amount < Decimal.Zero)
                {
                    String pattern = null;
                    switch (numberFormat.CurrencyNegativePattern)
                    {
                        case 0:
                            pattern = "({0}{1:N" + numberFormat.CurrencyDecimalDigits + "})";
                            break;
                        case 1:
                            pattern = numberFormat.NegativeSign + "{0}{1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 2:
                            pattern = "{0}" + numberFormat.NegativeSign + "{1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 3:
                            pattern = "{0}{1:N" + numberFormat.CurrencyDecimalDigits + "}" + numberFormat.NegativeSign;
                            break;
                        case 4:
                            pattern = "({1:N" + numberFormat.CurrencyDecimalDigits + "}{0})";
                            break;
                        case 5:
                            pattern = numberFormat.NegativeSign + "{1:N" + numberFormat.CurrencyDecimalDigits + "}{0}";
                            break;
                        case 6:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "}" + numberFormat.NegativeSign + "{0}";
                            break;
                        case 7:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "}{0}" + numberFormat.NegativeSign;
                            break;
                        case 8:
                            pattern = numberFormat.NegativeSign + "{1:N" + numberFormat.CurrencyDecimalDigits + "} {0}";
                            break;
                        case 9:
                            pattern = numberFormat.NegativeSign + "{0} {1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 10:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "} {0}" + numberFormat.NegativeSign;
                            break;
                        case 11:
                            pattern = "{0} {1:N" + numberFormat.CurrencyDecimalDigits + "}" + numberFormat.NegativeSign;
                            break;
                        case 12:
                            pattern = "{0}" + " " + numberFormat.NegativeSign + "{1:N" + numberFormat.CurrencyDecimalDigits + "}";
                            break;
                        case 13:
                            pattern = "{1:N" + numberFormat.CurrencyDecimalDigits + "}" + numberFormat.NegativeSign + " " + "{0}";
                            break;
                        case 14:
                            pattern = "({0} {1:N" + numberFormat.CurrencyDecimalDigits + "})";
                            break;
                        case 15:
                            pattern = "({1:N" + numberFormat.CurrencyDecimalDigits + "} {0})";
                            break;
                    }
                    formattedAmount = String.Format(cultureInfo, pattern, numberFormat.CurrencySymbol, amount * -1);
                }
                Console.WriteLine(formattedAmount);
            }
            Console.ReadKey();
        }
    }
