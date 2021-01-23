    /// <summary>Converts a decimal e.g. 1.5 to 1 hour 30 minutes</summary>
    /// <param name="duration">The time to convert as a double</param>
    /// <returns>
    ///		Returns a string in format:
    ///		x hours x minutes
    ///		x hours (if there's no minutes)
    ///		x minutes (if there's no hours)
    ///		Will also pluralise the words if required e.g. 1 hour or 3 hours
    /// </returns>
    public String convertDecimalToHoursMinutes(double time)
    {
    	TimeSpan timespan = TimeSpan.FromHours(time);
    	int hours = timespan.Hours;
    	int mins = timespan.Minutes;
    
    	// Convert to hours and minutes
    	String hourString = (hours > 0) ? string.Format("{0} " + pluraliseTime(hours, "hour"), hours) : "";
    	String minString = (mins > 0) ? string.Format("{0} " + pluraliseTime(mins, "minute"), mins) : "";
    
    	// Add a space between the hours and minutes if necessary
    	return ((hours > 0) && (mins > 0)) ? hourString + " " + minString : hourString + minString;
    }
    
    /// <summary>Pluralise hour or minutes based on the amount of time</summary>
    /// <param name="num">The number of hours or minutes</param>
    /// <param name="word">The word to pluralise e.g. "hour" or "minute"</param>
    /// <returns> Returns correct English pluralisation e.g. 3 hours, 1 minute, 0 minutes</returns>
    public String pluraliseTime(int num, String word)
    {
    	return (num == 0 || num > 1) ? word + "s" : word;
    }
