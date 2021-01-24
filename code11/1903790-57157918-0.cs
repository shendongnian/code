    List<DateTime?> dates = new List<DateTime?>()
    {
        new DateTime( 2016,10,05,00,00,00),
        null,
        null,
        null,
        new DateTime( 2016, 08, 12 ,07,46,00),
        null,
        null
    };
    DateTime? latest = null;
    for (int i = 0; i < dates.Count; i++)
    {
        if (dates[i].HasValue)
        {
            latest = dates[i];
        }
        else
        {
            dates[i] = latest;
        }
    }
