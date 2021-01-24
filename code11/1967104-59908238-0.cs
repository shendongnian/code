        static void Main(string[] args)
        {
            //Parse User input
            var inputValue = "1.345978";  decimal outputValue;
            var style = NumberStyles.AllowDecimalPoint;
            var culture = CultureInfo.InvariantCulture;
            if (Decimal.TryParse(inputValue, style, culture, out  outputValue))
                Console.WriteLine("Converted '{0}' to {1}.", inputValue, outputValue);
            else
                Console.WriteLine("Unable to convert '{0}'.", inputValue);
            //Rounding off 2 decimal places
            var roundedValue = Math.Round(outputValue, 2); 
        }
