    class ScheduleItem
    {
         DateTime start;
         DateTime end;
         string someText;
    }
    class OneSlot
    {
        list< ScheduleItem > ItemsInSlot;
    }
    list< OneSlot > VisibleSlots;
