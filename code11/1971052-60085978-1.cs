    List<DayOfWeek> DeliveryDays = new List<DayOfWeek>();
    public List<DateTime> GetAvailableDeliveryDates()
    {
        // 1. Get a range of numbers representing the days to add
        //      to today, which will make up our range of dates
        // 2. Select a date using Today.AddDays for each number 
        // 3. Filter on only days which are contained in DeliveryDays
        return Enumerable.Range(0, 21)  // Define the range           
            .Select(i => DateTime.Today.AddDays(i))  // Select the range
            .Where(date => DeliveryDays.Contains(date.DayOfWeek))  // Filter the range
            .ToList();
    }
