        public static IEnumerable<ClimateDailyData> ReadDailyData(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                yield break;
            int lineIndex = -1;
            foreach (string line in File.ReadLines(fileName))
            {
                lineIndex++;
                ClimateDailyData dayData = new ClimateDailyData();
                int i = 0;
                foreach (string field in ReadDailyDataFields(line))
                {
                    if (lineIndex == 0)
                    {
                        // handle latitude stuff
                        continue;
                    }
                    switch(i)
                    {
                        case 0:
                            dayData.DayDate = DateTime.ParseExact(field, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                            break;
                        case 2:
                            dayData.MaxTemp = double.Parse(field);
                            break;
                        case 3:
                            dayData.MinTemp = double.Parse(field);
                            break;
                        case 4:
                            dayData.Rain = double.Parse(field);
                            break;
                        case 5:
                            dayData.Pan = double.Parse(field);
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                yield return dayData;
            }
        }
        public static IEnumerable<string> ReadDailyDataFields(string text)
        {
            if (text == null)
                yield break;
            int lastPos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] == ' ') || (text[i] == '\t'))
                {
                    if (i > lastPos)
                    {
                        string field = text.Substring(lastPos, i - lastPos).Trim();
                        if (field.Length > 0)
                            yield return field;
                        lastPos = i + 1;
                    }
                }
            }
            if (text.Length > lastPos)
            {
                string field = text.Substring(lastPos, text.Length - lastPos).Trim();
                if (field.Length > 0)
                    yield return field;
            }
        }
