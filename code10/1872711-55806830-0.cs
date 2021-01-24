            System.Globalization.CultureInfo calture = new System.Globalization.CultureInfo("fa-Ir");
            System.Globalization.DateTimeFormatInfo info = calture.DateTimeFormat;
            info.AbbreviatedDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            info.DayNames = new string[] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            info.AbbreviatedMonthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            info.MonthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            info.AMDesignator = "ق.ظ";
            info.PMDesignator = "ب.ظ";
            info.ShortDatePattern = "yyyy/MM/dd";
            info.FirstDayOfWeek = DayOfWeek.Saturday;
            System.Globalization.PersianCalendar cal = new System.Globalization.PersianCalendar();
            var field = typeof(System.Globalization.DateTimeFormatInfo).GetField("calendar", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field?.SetValue(info, cal);
            var fieldInfo = typeof(System.Globalization.DateTimeFormatInfo).GetField("m_cultureTableRecord", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (fieldInfo != null)
            {
                object obj = fieldInfo.GetValue(info);
                var methodInfo = obj.GetType().GetMethod("UseCurrentCalendar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (
                    methodInfo !=
                    null)
                {
                    var propertyInfo = cal.GetType().GetProperty("ID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    if (
                        propertyInfo !=
                        null)
                        methodInfo.Invoke(obj, new object[] { propertyInfo.GetValue(cal, null) });
                }
            }
            var field1 = typeof(System.Globalization.CultureInfo).GetField("calendar", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field1?.SetValue(calture, cal);
            var fieldInfo1 = typeof(System.Globalization.CultureInfo).GetField("calendar", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            fieldInfo1?.SetValue(calture, cal);
            System.Threading.Thread.CurrentThread.CurrentCulture = calture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = calture;
            System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat = info;
            System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat = info;
