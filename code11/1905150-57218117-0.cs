    bool timeAdjustedByCode = false;
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        if (timeAdjustedByCode) {
            timeAdjustedByCode = false;
            return;
        }
        var dt = dateTimePicker1.Value;
        if (dt.Hour == 0) {
            if (dt.Date == dateTimePicker1.MinDate) {
                timeAdjustedByCode = true;
                dateTimePicker1.Value = dt.AddDays(1);
            }
            else {
                timeAdjustedByCode = true;
                dateTimePicker1.Value = dt.AddDays(-1);
            }
        }
        else if (dt.Hour < 22 && dt.Date == dateTimePicker1.MinDate.Date) {
            timeAdjustedByCode = true;
            dateTimePicker1.Value = dt.AddHours(1);
        }
    }
