    grid.Column("Summary", "Sum", format: (item) =>
    {
        if (item.WeekNumber == ViewBag.CurrentWeekNo)
        {
            return "Dolor";
        }
        else
        {
            return "Sit";
        }
    }
