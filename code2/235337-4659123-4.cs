        public static SelectList HolidayDays()
        {
            IList<SelectListItem> values = GenerateKeyValueList<HolidayCity>(HolidayCityHelper.GetFriendlyName, HolidayCity.NotSet);
            values = values.OrderBy(i => i.Text).ToList();
            SelectListItem newYork = values.FirstOrDefault(i => i.Text.Equals("New York"));
            SelectListItem london = values.FirstOrDefault(i => i.Text.Equals("London"));
            values.Remove(london);
            values.Insert(0, london);
            values.Remove(newYork);
            values.Insert(0, newYork);
            return new SelectList(values, "Value", "Text");
        }
