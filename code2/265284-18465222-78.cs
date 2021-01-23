	public static class Extensions
	{
	    public static DateTime? toDate(this string dateTimeStr, string[] dateFmt)
	    {
	      // example: var dt = "2011-03-21 13:26".toDate(new string[]{"yyyy-MM-dd HH:mm", 
	      //                                                  "M/d/yyyy h:mm:ss tt"});
	      const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
	      if (dateFmt == null)
	      {
	        var dateInfo = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
	        dateFmt=dateInfo.GetAllDateTimePatterns();
	      }
          // Commented out below because it can be done shorter as shown below
	      // DateTime? result = null;
	      // DateTime dt;
	      // if (DateTime.TryParseExact(dateTimeStr, dateFmt,
	      //    CultureInfo.InvariantCulture, style, out dt)) result = dt;
	      var result = (DateTime.TryParseExact(dateTimeStr, dateFmt,
	      	      CultureInfo.InvariantCulture, style, out var dt)) ? dt : null as DateTime?;
	      return result;
	    }
	    public static DateTime? toDate(this string dateTimeStr, string dateFmt=null)
	    {
	      // example:   var dt="2011-03-21 13:26".toDate("yyyy-MM-dd HH:mm");
		  // or simply  var dt="2011-03-21 13:26".toDate();        
	      // call overloaded function with string array param
	      string[] dateFmtArr = dateFmt == null ? null : new string[] { dateFmt };
		  return toDate(dateTimeStr, dateFmtArr);
		}
	}
