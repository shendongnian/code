    public IQueryable<TimeForm> GetTimeFormsWithStartAndEnd(DateTime start, DateTime end, string userId) {
        return this.Context.TimeForm
            .Include("Client") // Assuming your property to see the client is called "Client"
            .Include("Rate") // Same for "Rate"
            .Include("Task") // and "Task
            .Where(o => o.Start>= start 
                    && o.End<= end 
                    && o.USERID== userId));
    }
