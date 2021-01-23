        public static SelectList HolidayDays()
        {
            IList<SelectListItem> values = GenerateKeyValueList<HolidayCity>(HolidayCityHelper.GetFriendlyName, HolidayCity.NotSet);
            values = values.OrderByDescending(i => i.Text.Equals("New York"))
                .ThenByDescending(i => i.Text.Equals("London"))
                .ThenBy(i => i.Text).ToList();
            return new SelectList(values, "Value", "Text");
        }
