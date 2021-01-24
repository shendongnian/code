C#
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
                        if(minuteAggregateList.Any(node => node.ticker == data.ticker))
                        {
                             minuteAggregateList.Where(node => node.ticker == data.ticker)
                                                .Select({
                                                      val.results.AddRange(data.results); 
                                                      return val;
                                                        }).ToList();
                        }
                        else
                        {
                             minuteAggregateList.Add(data);
                        }
                    }
                }
                if (daysCount == 7)
                    break;
            }
        }
To add data to matched list, first need to select matched ticker (i.e using `Where()`).
And than after in `Select()` add result data.
After that changes are need to be apply on existing list using `ToList()`.
