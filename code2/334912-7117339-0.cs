    List<ClimateDailyData> dailyData;
    if (!File.Exists(FileName))
    {
        dailyData = new List<ClimateDailyData>();
    }
    else
    {
        List<string[]> lines = File.ReadLines(FileName)
                 .Where(l => !String.IsNullOrWhiteSpace(l))
                 .Select(l => l.Trim().Split(new char[] { ' ', '\t' })
                 .Where(f => !String.IsNullOrWhiteSpace(f))
                 .Select(f => f.Trim())
                 .ToList();
        Latitude = double.Parse(lines[0][0]);
        Longitude = double.Parse(lines[0][1]);
        dailyData = lines.Skip(2)
           .Select(fields => new ClimateDailyData
                   {
                       DayDate = DateTime.ParseExact(fields[0], "yyyyMMdd",
                                                     CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None),
                       MaxTemp = double.Parse(fields[2]),
                       MinTemp = double.Parse(fields[3]),
                       Rain = double.Parse(fields[4]),
                       Pan = double.Parse(fields[5])
                   })
           .ToList();
    }
    SetValue(() => DailyData, dailyData);
