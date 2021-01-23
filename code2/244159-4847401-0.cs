    public string DateToString(int year, int month, int day)
    {
        try
        {
            DateTime datetime = new DateTime(year, month, day);
            return datetime.ToString();
        }
        catch (Exception exObj)
        {
            //log error
            LogMyError(exObj);
            return DateTime.Now.ToString();
        }
    }
