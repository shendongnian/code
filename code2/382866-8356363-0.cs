    private Closure<Item, DateTime> closure = null;
    public IEnumerable<Item> GetDayData(DateTime day)
    {
        if (closure == null)
        {
            this.closure = new Closure<Item, DateTime>() {
                Predicate = i => i.IsValidForDay(this.closure.Variable)
            }
        }
        // assign here, else you only capture it the first time
        closure.Variable = day;
        this.items.Where(this.closure.Predicate);
    }
