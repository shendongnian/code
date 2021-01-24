    int dtPickerMinHour = 22;
    bool timeAdjustedByCode = false;
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        if (timeAdjustedByCode) { timeAdjustedByCode = false; return; }
        var dtp = sender as DateTimePicker;
        var dt = dtp.Value;
        if (dt.Hour == 0) {
            if (dt.Date == dtp.MinDate) {
                timeAdjustedByCode = true;
                dtp.Value = dt.AddDays(1);
            }
            else {
                timeAdjustedByCode = true;
                dtp.Value = dt.AddDays(-1);
            }
        }
        else if (dt.Hour < dtPickerMinHour && dt.Date == dtp.MinDate.Date) {
            timeAdjustedByCode = true;
            dtp.Value = dt.AddHours(1);
        }
    }
