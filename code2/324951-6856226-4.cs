    if (scheduleListBox.Items.Count == 0)
    {
        List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
        for (int i = 0; i < timeSplit.Length; i++)
        {
            string timeList = timeSplit[i];
            string titleList = titleSplit[i];
            string categoryList = categorySplit[i];
            ScheduleItem item = new ScheduleItem
                                    {
                                        Time = DateTime.Parse(timeList),
                                        Title = titleList,
                                        Category = categoryList
                                    };
            scheduleItems.Add(item);
        }
        
        scheduleItems.Sort();
    }
