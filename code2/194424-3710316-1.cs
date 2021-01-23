    public void AddToList()
    {
        List<Event> events = Events; // Get it out of the viewstate
        ... Add/Remove items here ...
        Events = events; // Add the updated list back into the viewstate
    }
