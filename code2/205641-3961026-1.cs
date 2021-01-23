    using System.Globalization;
    using System.Threading;
    
    protected void Application_BeginRequest()
                {
                    CultureInfo standardizedCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    standardizedCulture.DateTimeFormat.LongDatePattern = "yyyy-MM-dd hh:mm:ss";
                    standardizedCulture.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd hh:mm:ss";
                    standardizedCulture.DateTimeFormat.DateSeparator = "-";
                    Thread.CurrentThread.CurrentCulture = standardizedCulture;
                }
