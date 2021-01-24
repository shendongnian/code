    public class ExtendedField
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public Guid DataTypeId { get; set; }
        /// <summary>
        /// Can also be a typed class, this is just for reference
        /// </summary>
        /// <value>The field value.</value>
        public string FieldValue { get; set; }
        /// <summary>
        /// Incase of using string for fieldvalue, the string to format the value as per the required datatype 
        /// will be provided here.
        /// </summary>
        /// <value>The field value format string.</value>
        public string FieldValueFormatString { get; set; }
    }
    public class BaseModel
    {
        Dictionary<string, ExtendedField> ExtendedRows { get; set; }
    }
    public class Ticket : BaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
