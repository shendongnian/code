public Type GetConstants() =>
    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday
        || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        ? typeof(AllConstants.WeekendConstants)
        : typeof(AllConstants.WeekdayConstants);
