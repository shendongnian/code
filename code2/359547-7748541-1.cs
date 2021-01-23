    var czech = new CultureInfo("zh-CN");
    var MyReminders = ScheduledActionService.GetActions()
                    .Where(a => a.BeginTime.Date == Today);
                    .Select(a => a.BeginTime.Date.ToString("d",czech)
                    .ToArray();
