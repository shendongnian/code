    if (double.TryParse(data[i][2].ToString(),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out var temperature);
      IsOk();
    else
      IsNotOk();
