    /// <summary>
    /// Counts the number of minutes between <paramref name="from"/> and <paramref name="to"/>
    /// that fall between <paramref name="rangeStart"/> and <paramref name="rangeEnd"/>.
    /// </summary>
    /// <returns>The total minutes spanned between the given range.</returns>
    public static int GetMinutesInRange(DateTime from, DateTime to, TimeSpan rangeStart, TimeSpan rangeEnd) {
        int minutes = 0;
        bool overnight = rangeStart > rangeEnd;
        for (var m = from; m < to; m = m.AddMinutes(1)) {
            if (overnight) {
                if (rangeStart <= m.TimeOfDay || m.TimeOfDay < rangeEnd) {
                    minutes++;
                }
            } else {
                if (rangeStart <= m.TimeOfDay) {
                    if (m.TimeOfDay < rangeEnd) {
                        minutes++;
                    } else {
                        break;
                    }
                }
            }
        }
        return minutes;
    }
