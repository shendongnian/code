    string date = txtWorkingDate.Text;
    DateTime dateTime;
    string[] formats = new[] { "dd.MM.yyyy", "MM/dd/yyyy" };
    if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
    {
        args.IsValid = true;
    }
    else
    {
        args.IsValid = false;
    }
