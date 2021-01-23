    public static DateTime ConvertPayPalDateTime(string payPalDateTime)
    {
      // Get the offset.
      // If C# supports switching on strings, it's probably more sensible to do that.
      int offset;
      if (payPalDateTime.EndsWith(" PDT"))
      {
         offset = 7;
      }
      else if (payPalDateTime.EndsWith(" PST"))
      {
         offset = 8;
      }
      else
      {
        throw some exception;
      }
      // We've "parsed" the time zone, so remove it from the string.
      payPalDatetime = payPalDateTime.Substring(0,payPalDateTime.Length-4);
      // Same formats as above, but with PST/PDT removed.
      string[] dateFormats = { "HH:mm:ss MMM dd, yyyy", "HH:mm:ss MMM. dd, yyyy" };
      // Parse the date. Throw an exception if it fails.
      DateTime ret = DateTime.ParseExact(payPalDateTime, dateFormats, new CultureInfo("en-US"), DateTimeStyles.None, out outputDateTime);
      // Add the offset, and make it a universal time.
      return ret.AddHours(offset).SpecifyKind(DateTimeKind.Universal);
    }
