    public string PrintTaskDueTime(DateTime taskTime, DateTime currTime)
    {
        string result = string.Empty;
        TimeSpan timeDiff = TimeSpan.Zero;
        if(taskTime > currTime)
        {
            timeDiff = taskTime-currTime;
            result = String.Format("Your task is due in {0} days and {1} hours.", timeDiff.TotalDays, timeDiff.Hours);
        }
        else if(taskTime == currTime)
        {
            result = "Your task is due now!";
        }
        else
        {
            timeDiff = currTime-taskTime;
            result = String.Format("Your task is {0} days and {1} hours past due!", timeDiff.TotalDays, timeDiff.Hours);
        }
        
        return result;
    }
