    DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
        DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
    for (int x = 0; x <= otpLifespan; x++)
    {
        var result = NumericHOTP.Validate(hotp, key, 
            current.AddMinutes(-1 * x).Ticks);
        //return valid state if validation succeeded
        //return invalid state if the passed in value is invalid 
        //  (length, non-numeric, checksum invalid)
    }
    //return expired state
