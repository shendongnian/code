    public static Boolean Between(this DateTime input, DateTime minDate, DateTime maxDate)
    {
        // SQL takes limit in !
        return input >= minDate && input <= maxDate;
    }
