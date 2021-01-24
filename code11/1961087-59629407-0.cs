    public enum ReminderTypes
    {
        REMINDER_FLAGGED = 1,
        REMINDER_NORMAL = 2,
        REMINDER_WARNING = 3,
        REMINDER_IMPORTANT = 4
    }
    List<Reminder> ordered = reminders.OrderBy(x => x.ReminderType).ThenBy(x => x.ReminderDate).ToList();
    ordered.ForEach(x => Console.WriteLine(x.ReminderName));
**Output**
Reminder1
Reminder5
Reminder3
Reminder4
Reminder2
