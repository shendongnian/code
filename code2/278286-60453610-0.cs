    private static List<TimeBlock> GetDayOpenSlots(IEnumerable<TimeBlock> daySlots,
        IReadOnlyCollection<TimeBlock> usedDaySlots)
    {
        var freeTimeBlocks = new List<TimeBlock>();
        foreach (var daySlot in daySlots)
        {
            var selectedSlotsWithinRange = usedDaySlots
                .Where(x => x.StartTime >= daySlot.StartTime && x.EndTime <= daySlot.EndTime)
                .OrderBy(x => x.StartTime)
                .ToList();
            if (!selectedSlotsWithinRange.Any())
            {
                freeTimeBlocks.Add(daySlot);
                continue;
            }
            for (var i = 0; i < selectedSlotsWithinRange.Count - 1; i++)
            {
                var currentSlot = selectedSlotsWithinRange[i];
                var nextSlot = selectedSlotsWithinRange[i + 1];
                if (currentSlot.EndTime == nextSlot.StartTime)
                {
                    continue;
                }
                freeTimeBlocks.Add(new TimeBlock(currentSlot.EndTime,
                    nextSlot.StartTime));
            }
            var firstAppointment = selectedSlotsWithinRange.First();
            var lastAppointment = selectedSlotsWithinRange.Last();
            if (firstAppointment.StartTime > daySlot.StartTime)
            {
                freeTimeBlocks.Add(new TimeBlock(daySlot.StartTime,
                    firstAppointment.StartTime));
            }
            if (lastAppointment.EndTime < daySlot.EndTime)
            {
                freeTimeBlocks.Add(new TimeBlock(lastAppointment.EndTime, daySlot.EndTime));
            }
        }
        return freeTimeBlocks
            .OrderBy(x => x.StartTime)
            .ToList();
    }
