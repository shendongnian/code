    class ConfigurationItem : IFormattable
    {
        public string override ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "D") {
                return string.Format(formatProvider, "{0}: {1}\n", Name, Value);
            }
            return this.ToString(); // otherwise format as default
        }
    }
    class OptionalItem : IFormattable
    {
        public string override ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "D") {
                return string.Format(formatProvider, "{0}, ", Name);
            }
            return this.ToString(); // otherwise format as default
        }
    }
    string BuildDataRowString(this IEnumerable e, string format)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var o in e) sb.AppendFormat("{0:D}", o);
        return sb.ToString();
    }
