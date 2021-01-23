    public enum RecurrenceType
    {
        //Values
    }
    public enum RecurrenceFrequency
    {
        //Values
    }
    public interface IEquipment
    {
        bool IsPMRequired();
        RecurrenceType RecurrenceType { get; }
        RecurrenceFrequency RecurrenceFrequency { get; }
        //You may want to choose something other than object, or eliminate this property
        object RecurrenceValue { get; set; } 
    }
