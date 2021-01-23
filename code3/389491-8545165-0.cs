    private void DBIO_Morning()
    {
        DateTime date_current = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
        Action setValue = () => DTPicker_start.Value = date_current;
        if (DTPicker_start.InvokeRequired)
            DTPicker_start.Invoke(setValue);
        else
            setValue();
    }
