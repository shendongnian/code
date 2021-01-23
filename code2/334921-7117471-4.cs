    List<ClimateDailyData> dailyData;
    if (!File.Exists(FileName))
    {
        dailyData = new List<ClimateDailyData>();
    }
    else
    {
        dailyData = File
                 .ReadLines(FileName)
                 .Where(line => !String.IsNullOrWhiteSpace(line))
                 .Skip(2)
                 .Select(line => line.Split(new [] { ' ', '\t' },
                                            StringSplitOptions.RemoveEmptyEntries))
                 .Select(fields => new ClimateDailyData
                  {
                       DayDate = new DateTime(
                           int.Parse(fields[0].Substring(0, 4)),
                           int.Parse(fields[0].Substring(4, 2)),
                           int.Parse(fields[0].Substring(6, 2))),
                       MaxTemp = double.Parse(fields[2]),
                       MinTemp = double.Parse(fields[3]),
                       Rain = double.Parse(fields[4]),
                       Pan = double.Parse(fields[5])
                  })
                 .ToList();
    }
    SetValue(() => DailyData, dailyData);
