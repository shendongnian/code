cs
IEnumerable<CapOrderTimeSlot>[] dummyDates = new IEnumerable<CapOrderTimeSlot>[DayCount];
for (int i = 0; i < DayCount; i++)
{
    int temp = i;
    dummyDates[i] = OrderSlots.Where(os => os.ComputedStartDate == FirstDate.AddDays(temp));
}
