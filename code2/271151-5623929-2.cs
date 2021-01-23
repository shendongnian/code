    public abstract class Recurrence : IDisposable
    {
        public static Boolean IsDue(IHaveRecurrence recurringObj)
        {
            using (var recurrence = RecurrenceFactory.GetRecurrence(recurringObj.RecurrenceType))
            {
                return recurrence.GetIsDue(recurringObj);
            }
        }
        protected abstract Boolean GetIsDue(IHaveRecurrence recurringObj);
    }
