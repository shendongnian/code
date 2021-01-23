    public static bool IsDateTime(string txtDate)
    {
       DateTime tempDate;
       return DateTime.TryParseExact(txtDate,"dd/MM/yyyy",
                                     new CultureInfo("pt-BR"),
                                     DateTimeStyles.None, out tempDate);
    }
