        public static double Xirr(IList<double> values, IList<DateTime> dates)
        {
            var xlApp = new Application();
            var datesAsDoubles = new List<double>();
            foreach (var date in dates)
            {
                var totalDays = (date - DateTime.MinValue).TotalDays;
                datesAsDoubles.Add(totalDays);
            }
            var valuesArray = values.ToArray();
            var datesArray = datesAsDoubles.ToArray();
            return xlApp.WorksheetFunction.Xirr(valuesArray, datesArray);
        }
