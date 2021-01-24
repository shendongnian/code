    DateTime dt;
    DateTime.TryParseExact("21/4/2019 11:6:56",
                           "dd/M/yyyy hh:m:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out dt);
