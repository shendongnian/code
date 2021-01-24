        static void Main(string[] args)
        {
      
            //Parse User input
            var inputValue = Console.ReadLine();
            inputValue = inputValue.Split('%')[0]; //To handle the trailing % sign
    
            decimal outputValue;
            var style = NumberStyles.Any;
            var culture = CultureInfo.InvariantCulture;
            if (Decimal.TryParse(inputValue, style, culture, out outputValue))
                Console.WriteLine("Converted '{0}' to {1}.", inputValue, outputValue);
            else
                Console.WriteLine("Unable to convert '{0}'.", inputValue);
    
            //Rounding off 2 decimal places
    
            var roundedValue = Math.Round(outputValue, 2);
            Console.WriteLine(roundedValue);
            Console.Read();
        }
