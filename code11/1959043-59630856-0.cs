    var gamePlayLogsResponse = JsonObject.Parse(userGameLogs.downloadHandler.text);
    totalUnlockedLevels = 1;
    if (gamePlayLogsResponse["status"].GetString() == "success")
    {
        var data = gamePlayLogsResponse["data"].GetObject();
        // get the data for the selected year, if there is any
        var year = data.GetNamedObject(CalendarController.year, null);
        if (year != null)
        {
            Debug.Log($"Found data for selected year: {CalendarController.year}");
            // get the data for the selected month, if there is any
            var month = year.GetNamedObject(CalendarController.month, null);
            if (month != null)
            {
                Debug.Log($"Found data for selected month: {CalendarController.month}");
                var consecutive = month["consecutive"].GetArray();
                Debug.Log($"consectiveLength     {consecutive.Count}");
                foreach (var groupObject in consecutive)
                {
                    var group = groupObject.GetArray();
                    int totalConsective = group.Count;
                    for(int i = 0; i < totalConsective; i ++)
                    {
                        var day = Convert.ToInt32(group[i].GetNumber());
                        Debug.Log($"Day {i}: {day}");
                        if (i == 0)
                        {
                            Debug.Log("Show start of consecutive block in the calendar");
                            CalendarController._dateItems[day].GetComponent<Image>().sprite = consStartSprite;
                        }
                        if (i > 1 && i < totalConsective - 1)
                        {
                            Debug.Log("Show middle of consecutive block in calendar");
                            CalendarController._dateItems[day].GetComponent<Image>().sprite = consContinueSprite;
                        }
                        if (i == totalConsective - 1)
                        {
                            Debug.Log("Show end of consecutive block in calendar");
                            CalendarController._dateItems[i].GetComponent<Image>().sprite = consEndSprite;
                            Debug.Log(CalendarController._dateItems[i].name);
                        }
                    }
                }
                var nonConsecutive = month["non_consecutive"].GetArray();
                Debug.Log($"nonConsectiveLength     {nonConsecutive.Count}");
                foreach (var dayObject in nonConsecutive)
                {
                    var day = Convert.ToInt32(dayObject.GetNumber());
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
