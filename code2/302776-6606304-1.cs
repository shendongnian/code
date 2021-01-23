    DateTime IncentiveDate;
        /// <summary>
        /// Input Format: ddMMyy eg. 070711
        /// Output Format: dd-MMM-YYYY eg. 07-JUL-2011
        /// </summary>
        public string IncentiveDateAsString
        {
            set
            {
                DateTime.TryParseExact(value, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out IncentiveDate);
            }
            get
            {
                return IncentiveDate.ToString("dd-MMM-yyyy");
            }
        }
