            timeEndDate = timeStartDate.AddYears(1); // or .AddMonts etc..
            rangeTimeSpan = timeEndDate.Subtract(timeStartDate); //declared prior as TimeSpan object
            rangeTimeArray = new DateTime[rangeTimeSpan.Days]; //declared prior as DateTime[]
            for (int i = 0; i < rangeTimeSpan.Days; i++)
            {
                timeStartDate = timeStartDate.AddDays(1);
                rangeTimeArray[i] = timeStartDate;
            }
