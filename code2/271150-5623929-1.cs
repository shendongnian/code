    internal sealed class RecurrenceFactory
    {
        public Recurrence GetRecurrence(RecurrenceType type)
        {
            switch (type)
            {
                case Daily: return new DailyRecurrence;
                :
            }
        }
    }
