    /// <summary>
    /// Returns the number of weeks between two datetimes
    /// </summary>
    /// <param name="cal"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public static int GetWeeks(this GregorianCalendar cal,
                                    CalendarWeekRule weekRule,
                                    DayOfWeek dayofWeek,
                                    DateTime startDate,
                                    DateTime endDate) {
        int startWeekNumber = 0;
        int endWeekNumber = 0;
        int numberOfWeeksInRange = 0;
        if (startDate.Year == endDate.Year) {
            startWeekNumber = 0;
            endWeekNumber = 0;
            startWeekNumber = cal.GetWeekOfYear(startDate,
                                                weekRule,
                                                dayofWeek);
            endWeekNumber = cal.GetWeekOfYear(endDate,
                                              weekRule,
                                              dayofWeek);
            numberOfWeeksInRange = endWeekNumber - startWeekNumber;
        }
        else { // calculate per year, inclusive
            for (int year = startDate.Year; year <= endDate.Year; year++) {
                startWeekNumber = 0;
                endWeekNumber = 0;
                if (year == startDate.Year) { // start date through the end of the year
                    startWeekNumber = cal.GetWeekOfYear(startDate, weekRule, dayofWeek);
                    endWeekNumber = cal.GetWeekOfYear((new DateTime(year + 1, 1, 1).AddDays(-1)),
                        weekRule, dayofWeek);
                }
                else if (year == endDate.Year) { // start of the given year through the end date
                    startWeekNumber = cal.GetWeekOfYear((new DateTime(year, 1, 1)),
                        weekRule, dayofWeek);
                    endWeekNumber = cal.GetWeekOfYear(endDate,
                        weekRule, dayofWeek);
                }
                else { // calculate the total number of weeks in this year                
                    startWeekNumber = cal.GetWeekOfYear(new DateTime(year, 1, 1),
                        weekRule, dayofWeek);
                    endWeekNumber = cal.GetWeekOfYear((new DateTime(year + 1, 1, 1).AddDays(-1)),
                        weekRule, dayofWeek;
                }
                numberOfWeeksInRange += endWeekNumber - startWeekNumber;
            }
        }
        return numberOfWeeksInRange;
    }
