	public class DoubleFormatter : IFormatProvider, ICustomFormatter 
	{
		// Implementation of IFormatProvider:
		public object GetFormat(Type t) {
			if (t == typeof(ICustomFormatter)) {
				return this;
			}
			return null;
		}
		// Implementation of ICustomFormatter:
		public string Format(string format, object arg, IFormatProvider provider) {
			// Search for the custom "EE" format specifier:
			if (format == null || !format.StartsWith("EE")) return null;
			format = format.Substring(2); // Trim "EE"
			// Determine how many digits before we cutoff:
			int digits;
			if (!int.TryParse(format, out digits)) {
				throw new FormatException("Format must contain digits");
			}
			
			// Get the value: (note, this will work for any numeric type)
			var value = Convert.ToDouble(arg);
			// Convert to string without using Exponential format:
			var output = value.ToString("0."+(new string('#',digits)), provider);
			// Determine how many digits are showing: (this part isn't culture-compatible)
			var length = output.Length - output.IndexOf(".");
			if (length <= digits) {
				return output;
			} else {
				return value.ToString("E"+format, provider);
			}
		}
	}
