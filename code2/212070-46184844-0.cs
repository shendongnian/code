    public class StringFormatEx : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// ICustomFormatter member
        /// </summary>
        public string Format(string format, object argument, IFormatProvider formatProvider)
        {
            #region func-y town
            Func<string, object, string> handleOtherFormats = (f, a) => 
            {
                var result = String.Empty;
                if (a is IFormattable) { result = ((IFormattable)a).ToString(f, CultureInfo.CurrentCulture); }
                else if (a != null) { result = a.ToString(); }
                return result;
            };
            #endregion
            //reality check.
            if (format == null || argument == null) { return argument as string; }
            //perform default formatting if arg is not a string.
            if (argument.GetType() != typeof(string)) { return handleOtherFormats(format, argument); }
            //get the format specifier.
            var specifier = format.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture);
            //perform extended formatting based on format specifier.
            switch(specifier)
            {
                case "L": 
                    return LengthFormatter(format, argument);
                default:
                    return handleOtherFormats(format, argument);
            }
        }
        /// <summary>
        /// IFormatProvider member
        /// </summary>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        /// <summary>
        /// Custom length formatter.
        /// </summary>
        private string LengthFormatter(string format, object argument)
        {
            //specifier requires length number.
            if (format.Length == 1)
            {
                throw new FormatException(String.Format("The format of '{0}' is invalid; length is in the form of Ln where n is the maximum length of the resultant string.", format));
            }
            //get the length from the format string.
            int length = int.MaxValue;
            int.TryParse(format.Substring(1, format.Length - 1), out length);
            //returned the argument with length applied.
            return argument.ToString().Substring(0, length);
        }
    }
