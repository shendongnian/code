public static T TryParse<T>(String value, T defaultValue) where T : struct {
	if (String.IsNullOrWhiteSpace(value)) {
		return defaultValue;
	}
	T result;
	if (!Enum.TryParse(value, out result)) {
		if (Enum.IsDefined(typeof (T), result) | result.ToString().Contains(",")) {
			// do nothing
		} else {
			result = defaultValue;
		}
	} else {
		result = defaultValue;
	}
	return result;
}
