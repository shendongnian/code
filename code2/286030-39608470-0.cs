    public DateTime ConvertLongFormate2DateTime(long iDatelongValue)
    {
        try
        {
            var iSecondCal = (iDatelongValue / 1000 + 8 * 60 * 60);
            var startDate = new DateTime(1970, 01, 01);
            DateTime resultDateTime = startDate.AddSeconds(iSecondCal);
            return resultDateTime;
        }
        catch (Exception)
        {
            throw;
        }
    }
