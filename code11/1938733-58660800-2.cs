c#
private static DateTime ParseDate(string providedDate) {
	DateTime validDate;
	string[] formats = {
		"yyyy-MM-ddTHH:mm:ss"
	};
	var dateFormatIsValid = DateTime.TryParseExact(
	providedDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);
	return dateFormatIsValid ? validDate: DateTime.MinValue;
}
Then, use this function to convert the string. I am replacing UTC+1 to empty string
c#
static void Main(string[] args) {
	string strdatetime = "2019-09-23T08:34:00UTC+1";
	DateTime dateTime = ParseDate(strdatetime.Replace("UTC+1", ""));
	Console.WriteLine(dateTime);
}
