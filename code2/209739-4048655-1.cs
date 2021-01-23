    static class DateTimeExtensions
    {
       static IDictionary<DateTime, VendorSpecificDayEnum> m_VendorSpecificDays = new Dictionary<DateTime, VendorSpecificDayEnum>();
       public static VendorSpecificDayEnum GetVenderSpecificDay(/*this*/ DateTime dt)
       {
          return m_VendorSpecificDays[dt];
       }
    }
