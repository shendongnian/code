    abstract class Equipment
    {
          protected abstract Recurrence PMRecurrence
          {
                get;
          }
          public bool IsPMDue(DateTime dateAndTime)
          {
                 return PMRecurrence.IsDue(dateAndTime);
          }
     }
