    public EventContainer(...)
    {
        EventRaiser er = new EventRaiser();
        er.AfterSearch += this.OnAfterSearch;
    }
    public void OnAfterSearch()
    {
       // Handle AfterSearch event
    }
