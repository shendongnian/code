    public IQueryable<TimeForm> GetTimeForms() {
        return this.Context.TimeForm
            .Include("Client") // Assuming your property to see the client is called "Client"
            .Include("Rate") // Same for "Rate"
            .Include("Task"); // and "Task
    }
