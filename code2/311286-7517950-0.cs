    using System;
    using System.Globalization;
 
    public static class PayPalTransaction
    {
        public static DateTime ConvertPayPalDateTime(string payPalDateTime)
        {
        // accept a few different date formats because of PST/PDT timezone and slight month difference in sandbox vs. prod.
            string[] dateFormats = { "HH:mm:ss MMM dd, yyyy PST", "HH:mm:ss MMM. dd, yyyy PST", "HH:mm:ss MMM dd, yyyy PDT", "HH:mm:ss MMM. dd, yyyy PDT" };
            DateTime outputDateTime;
 
            DateTime.TryParseExact(payPalDateTime, dateFormats, new CultureInfo("en-US"), DateTimeStyles.None, out outputDateTime);
 
            // convert to local timezone
            outputDateTime = outputDateTime.AddHours(3);
 
            return outputDateTime;
        }
    }
