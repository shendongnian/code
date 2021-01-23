    RecordList = new ArrayList(
             RecordList.Cast<string>().OrderBy(s => s.Substring(3,3))
                       .ThenBy(s => int.Parse(s.Substring(0,3)))
                       .ThenByDescending(s => double.Parse(s.Substring(6,4)))
              .ToArray());
