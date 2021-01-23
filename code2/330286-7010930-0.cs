            DateTime StartDate;
            DateTime EndDate;
            DateTime tempDate = StartDate;
            List<DateTime> dateToEvaluate;
            Dictionary<DateTime, List<Task>> dateTaskDict = new Dictionary<DateTime, List<Task>>();
            bool TimeIsPresent = false;
            foreach (Task tempItem in TaskList)
            {
                while (EndDate.AddDays(1) != tempDate)
                {
                    if (tempItem.Date[0] == tempDate)
                    {
                        List<Task> tasksForDate;
                        if (!dateTaskDict.TryGetValue(tempDate, out tasksForDate))
                        {
                            tasksForDate = new List<Task>();
                            dateTaskDict[tempDate] = tasksForDate;
                        }
                        tasksForDate.Add(tempItem);
                        break;
                    }
                    tempDate = tempDate.AddDays(1);
                }
            }
            tempDate = StartDate;
            while (EndDate.AddDays(1) != tempDate)
            {
                List<Task> tasks;
                if (dateTaskDict.TryGetValue(tempDate, out tasks))
                {
                    foreach (Task aTask in tasks)
                        tempTask.Add(new GroupedTask { ID = null,
                                                   TaskID = null,
                                                   Date = dateToEvaluate });
                }
                else
                {
                    if (tempDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        tempTask.Add(new GroupedTask { ID = aTask.ID,
                                                   TaskID = aTask.TaskID,
                                                   Date = tempDate });
                    }
                }
                if (!(tempDate.DayOfWeek == DayOfWeek.Sunday))
                {
                    dateToEvaluate = new List<DateTime>();
                    dateToEvaluate.Add(tempDate);
                    tempTask.Add(new GroupedTask { ID = null,
                                                   TaskID = null,
                                                   Date = dateToEvaluate });
                 }
            }
