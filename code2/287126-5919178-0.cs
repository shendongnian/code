        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);
        }
        public static void ArgumentInRange(decimal argument, decimal minValue, decimal maxValue, string argumentName)
        {
            if (argument < minValue || argument > maxValue)
            {
                throw new ArgumentOutOfRangeException(
                    argumentName,
                    FormatUtilities.Format("Argument out of range: {0}. Must be between {1} and {2}.", argument, minValue, maxValue));
            }
        }
        public static void ArgumentState(bool expression, string argumentName, string formatText, params object[] args)
        {
            if (!expression)
                throw new ArgumentException(FormatUtilities.Format(formatText, args), argumentName);
        }
        public static void ArgumentHasText(string argument, string argumentName)
        {
            ArgumentNotNull(argument, argumentName);
            ArgumentState(argument.Length > 0, argumentName, "Argument cannot be an empty string.");
        }
