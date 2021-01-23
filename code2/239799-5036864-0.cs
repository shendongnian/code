    /// <summary>
    /// Represents the formula used for converting date serial values stored within the workbook into DateTime instances.
    /// </summary>
    /// <remarks>
    /// Information on date serial conversion is available here: http://www.documentinteropinitiative.com/implnotes/ISO-IEC29500-2008/001.018.017.004.001.000.000.aspx
    /// </remarks>
    public enum XlsxDateCompatibility
    {
        /// <summary>
        /// Standard dates are based on December 30, 1899 and are considered "Standard 1900" dates.
        /// </summary>
        StandardBase1900,
        /// <summary>
        /// Excel for Windows backwards compatible dates are based on December 31, 1899 are are considered "Backwards compatible 1900" dates.
        /// </summary>
        BackwardsCompatibleBase1900,
        /// <summary>
        /// Excel for Macintos backwards compatible dates are based on January 1, 1904 and are considered "1904" dates.
        /// </summary>
        BackwardsCompatibleBase1904
    }
		private static readonly IDictionary<XlsxDateCompatibility, DateTime> _dateSerialBaseDates
			= new Dictionary<XlsxDateCompatibility, DateTime>
			  	{
			  		{XlsxDateCompatibility.StandardBase1900, new DateTime(1899, 12, 30)},
			  		{XlsxDateCompatibility.BackwardsCompatibleBase1900, new DateTime(1899, 12, 31)},
			  		{XlsxDateCompatibility.BackwardsCompatibleBase1904, new DateTime(1904, 1, 1)}
			  	};
		public static DateTime DateSerialToDateTime(double dateSerial, XlsxDateCompatibility dateCompatibility)
		{
			
			// special case for dateCompaitility 1900, Excel thinks 1900 is a leap year
			// http://support.microsoft.com/kb/214019
			if (dateCompatibility == XlsxDateCompatibility.BackwardsCompatibleBase1900 && dateSerial >= 61.0)
			{
				dateSerial -= 1;
			}
			DateTime baseDate;			
			if (!_dateSerialBaseDates.TryGetValue(dateCompatibility, out baseDate))
			{
				baseDate = _dateSerialBaseDates[XlsxDateCompatibility.StandardBase1900];
			}
			return baseDate.AddDays(dateSerial);
		}
