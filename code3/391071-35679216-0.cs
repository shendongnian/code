     public sealed class GenericDateTimeFormatType
        {
           
            public static readonly GenericDateTimeFormatType Format1 = new GenericDateTimeFormatType("dd-MM-YYYY");
            public static readonly GenericDateTimeFormatType Format2 = new GenericDateTimeFormatType("dd-MMM-YYYY");
    
            private GenericDateTimeFormatType(string Format)
            {
                _Value = Format;
            }
    
            public string _Value { get; private set; }
        }
