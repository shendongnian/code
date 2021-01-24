        var gamePlayLogsResponse = JsonConvert.DeserializeObject<gamePlayLogs>(userGameLogs.downloadHandler.text);
        totalUnlockedLevels = 1;
        if (gamePlayLogsResponse.status == "success")
        {
            if (gamePlayLogsResponse.Data.TryGetValue(CalendarController.year, out Dictionary<string, Month> year))
            {
                Debug.Log($"Found data for selected year: {CalendarController.year}");
                // get the data for the selected month, if there is any
                if (year.TryGetValue(CalendarController.month, out Month month))
                {
                    Debug.Log($"Found data for selected month: {CalendarController.month}");
                    Debug.Log($"consectiveLength     {month.Consecutive.Length}");
                    foreach (var group in month.Consecutive)
                    {
                        for (int i = 0; i < group.Length; i++)
                        {
                            var day = group[i];
                            Debug.Log($"Day {i}: {day}");
                            if (i == 0)
                            {
                                Debug.Log("Show start of consecutive block in the calendar");
                                CalendarController._dateItems[day].GetComponent<Image>().sprite = consStartSprite;
                            }
                            if (i > 1 && i < group.Length - 1)
                            {
                                Debug.Log("Show middle of consecutive block in calendar");
                                CalendarController._dateItems[day].GetComponent<Image>().sprite = consContinueSprite;
                            }
                            if (i == group.Length - 1)
                            {
                                Debug.Log("Show end of consecutive block in calendar");
                                CalendarController._dateItems[i].GetComponent<Image>().sprite = consEndSprite;
                                Debug.Log(CalendarController._dateItems[i].name);
                            }
                        }
                    }
                    Debug.Log($"nonConsectiveLength     {month.NonConsecutive.Length}");
                    foreach (var day in month.NonConsecutive)
                    {
                        Debug.Log("Show non-consecutive block in calendar");
                        CalendarController._dateItems[day].GetComponent<Image>().sprite = nonConsSprite;
                        Debug.Log($"Day: {day}");
                    }
                }
                else
                {
                    Debug.Log($"NO DATA for selected month: {CalendarController.month}");
                }
            }
            else
            {
                Debug.Log($"NO DATA for selected year: {CalendarController.year}");
            }
        }
