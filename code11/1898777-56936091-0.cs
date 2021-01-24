    var dateList = GetDatesFromDB();
    Style dayButtonStyle = new Style() { BasedOn = (Style)this.Resources["calendarDayButtonStyle"] };
    foreach (DateObject date in dateList)
    {
        var dataTrigger = new DataTrigger() { Binding = new Binding("Date"), Value = new DateTime(date.Year, date.Month, date.Day) };
        dataTrigger.Setters.Add(new Setter(FontWeightProperty, FontWeights.Bold));
        dayButtonStyle.Triggers.Add(dataTrigger);
    }
    dayButtonStyle.Seal();
    calendarDayButtonStyle.CalendarDayButtonStyle = dayButtonStyle;
