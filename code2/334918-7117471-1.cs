    List<ClimateDailyData> dailyData;
    if (!File.Exists(FileName))
    {
        dailyData = new List<ClimateDailyData>();
    }
    else
    {
        dailyData = File
                 .ReadLines(FileName)
                 .Where(l => !String.IsNullOrWhiteSpace(l))
                 .Select(l => l
                     .Trim()
                     .Split(new char[] { ' ', '\t' })
                     .Where(f => !String.IsNullOrWhiteSpace(f))
                     .Select(f => f.Trim())
                     .ToArray())
                 .Skip(2)
                 .Select(fields => new ClimateDailyData
                   {
                       DayDate = new DateTime(
                           int.Parse(field[0].Substring(0, 4)),
                           int.Parse(field[0].Substring(4, 2)),
                           int.Parse(field[0].Substring(6, 2))),
                       MaxTemp = double.Parse(fields[2]),
                       MinTemp = double.Parse(fields[3]),
                       Rain = double.Parse(fields[4]),
                       Pan = double.Parse(fields[5])
                   })
                 .ToList();
    }
    SetValue(() => DailyData, dailyData);
