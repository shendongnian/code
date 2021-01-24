public static List<RootObject> minuteAggregateList = new List<RootObject>();
public void historicalMinuteAggData(string symbol)
        {
            int daysCount = 0;
            for(int i=1; i<=20; i++)
            {
                DateTime date = DateTime.Now.Date.AddDays(-i);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysCount++;
                    var startUnixTime = (date.Add(new TimeSpan(13, 30, 00)).Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
                    var endUnixTime = (date.Add(new TimeSpan(20, 00, 00)).Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
                    using (var reader = new StreamReader(new WebClient().OpenRead(string.Format("API For Fetch Data"))))
                    {
                        var x = reader.ReadLine();
                        RootObject data = JsonConvert.DeserializeObject<RootObject>(x);
                        if (chk != null)
                        {
                            minuteAggregateList.Single(q => q.ticker == symbol).results.InsertRange(0, data.results);
                        }
                        else
                            minuteAggregateList.Add(data);
                    }
                }
                if (daysCount == 7)
                    break;
            }
        }
