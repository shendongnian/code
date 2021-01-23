        /// <summary>
        /// Seriously?  For the loss
        /// <see cref="http://www.debugging.com/bug/19252"></see>
        /// </summary>
        /// <param name="excelDate">Number of days since 1900-01-01</param>
        /// <returns>The converted days to date</returns>
        public static DateTime ConvertXlsdtToDateTime(int excelDate)
        {
            DateTime dt = new DateTime(1899, 12, 31);
            // adjust for 29 Feb 1900 which Excel considers a valid date
            if (excelDate >= 60)
            {
                excelDate--;
            }
            return dt.AddDays(excelDate);
        }
