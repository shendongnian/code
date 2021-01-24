        public async Task ScheduleNotices()
        {
            var schedules = await _dbContext.Schedules
                .Include(x => x.User)
                .ToListAsync().ConfigureAwait(false);
            if (!schedules.HasAny())
            {
                return;
            }
            foreach (var schedule in schedules)
            {
                var today = DateTime.UtcNow.Date;
                // schedule notification only if not already scheduled for today
                if (schedule.LastScheduledDateTime == null || schedule.LastScheduledDateTime.Value.Date < today)
                {
                    //construct scheduled datetime for today
                    var scheduleDate = new DateTime(today.Year, today.Month, today.Day, schedule.PreferredTime.Hours, schedule.PreferredTime.Minutes, schedule.PreferredTime.Seconds, DateTimeKind.Unspecified);
                    // convert scheduled datetime to UTC
                    schedule.LastScheduledDateTime = TimeZoneInfo.ConvertTimeToUtc(scheduleDate, TimeZoneInfo.FindSystemTimeZoneById(schedule.User.TimeZone));
                    //*** i think we dont have to convert to DateTimeOffSet since LastScheduledDateTime is already in UTC
                    var dateTimeOffSet = new DateTimeOffset(schedule.LastScheduledDateTime.Value);
                    BackgroundJob.Schedule<INotificationService>(x => x.Notify(schedule.CompanyUserID), dateTimeOffSet);
                }
   		   }
            await _dbContext.SaveChangesAsync();
        }
