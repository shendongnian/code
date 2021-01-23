    private string _LastRange = string.Empty;
    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
      if (monthCalendar1.SelectionRange.ToString() != _LastRange) {
        _LastRange = monthCalendar1.SelectionRange.ToString();
        List<TimestampInfo> displayTimestamps = databaseManger.QueryForTimestamps(DayPicker.SelectionRange);
        if (displayTimestamps == null) return;
        TimestampsListBox.Items.Clear();
        TimestampsListBox.Items.AddRange(displayTimestamps.ToArray());
      }
    }
