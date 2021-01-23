    public interface IHaveRecurrence
    {
        DateTime? LastOccurrence { get; }
        RecurrenceType RecurrenceType { get; }
        Int32 RecurrenceValue { get; }
        Boolean IsDue();
    }
