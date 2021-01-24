    private static List<DataRecord> Get(List<DataRecord> myList)
        {
            var ordered = myList.OrderBy(x => x.MeasurementDate.TimeOfDay).ToList();
            int i = 0;
            int count = myList.Count();
            var temp =
                (from s in ordered
                let index = ++i
                let next = ordered.ElementAtOrDefault(index != count ? index : 0)
                select new
                {
                    Cur = s.MeasurementDate,
                    Diff = index != count
                        ? (next.MeasurementDate.TimeOfDay - s.MeasurementDate.TimeOfDay).TotalMinutes
                        : 24 * 60 - (ordered.ElementAtOrDefault(count - 1).MeasurementDate.TimeOfDay - ordered.ElementAtOrDefault(0).MeasurementDate.TimeOfDay).TotalMinutes
                }).ToList();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            count = 0;
            double minutes = 0;
            for (int index = 0; index < temp.Count(); index++)
            {
                for (int j = index; j < temp.Count(); j++)
                {
                    minutes += temp[j].Diff;
                    if (minutes > 60)
                    {
                        dict.Add(index, count);
                        count = 0;
                        minutes = 0;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            var max = dict.First(d => d.Value == dict.Values.Max());
            var finalResult = ordered.Skip(max.Key).Take(max.Value + 1).ToList();
            return finalResult;
        }
