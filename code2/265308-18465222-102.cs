	public static class Extensions
	{
	    // Extension method parsing a date string to a DateTime?
	    // dateFmt is optional and allows to pass a parsing pattern array
        // or one or more patterns passed as string parameters
	    public static DateTime? ToDate(this string dateTimeStr, params string[] dateFmt)
	    {
	      // example: var dt = "2011-03-21 13:26".ToDate(new string[]{"yyyy-MM-dd HH:mm", 
	      //                                                  "M/d/yyyy h:mm:ss tt"});
	      // or simpler: 
	      // var dt = "2011-03-21 13:26".ToDate("yyyy-MM-dd HH:mm", "M/d/yyyy h:mm:ss tt");
	      const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
	      if (dateFmt == null)
	      {
	        var dateInfo = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
	        dateFmt=dateInfo.GetAllDateTimePatterns();
	      }
          // Commented out below because it can be done shorter as shown below.
          // For older C# versions (older than C#7) you need it like that:
	      // DateTime? result = null;
	      // DateTime dt;
	      // if (DateTime.TryParseExact(dateTimeStr, dateFmt,
	      //    CultureInfo.InvariantCulture, style, out dt)) result = dt;
	      // In C#7 and above, we can simply write:
	      var result = DateTime.TryParseExact(dateTimeStr, dateFmt, CultureInfo.InvariantCulture,
	                   style, out var dt) ? dt : null as DateTime?;
	      return result;
	    }
	}
