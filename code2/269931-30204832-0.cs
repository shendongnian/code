    public static class ObjectUtil {
		public static string ToCsvString(this object obj) {
			string result = obj.ToString();
			if (result.Contains("\"")) {
				result = result.Replace("\"", "\"\"");
			}
			if (result.Contains(",")) {
				result = string.Format("\"{0}\"", result);
			}
			if (result.Contains(Environment.NewLine)) {
				result = string.Format("\"{0}\"", result);
			}
			return result;
		}
	}
