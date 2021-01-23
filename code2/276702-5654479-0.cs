    using System;
    using FileHelpers;
    
    namespace ReadDataFromFile
    {
        [DelimitedRecord(" ")] 
        public class DataClass
        {
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string EbbField;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string CompoundField;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string VegiField;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string C1Field;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string O1Field;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string A1Field;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string B1Field;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string C2Field;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string MlField;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string DollarField1;
            [FieldQuoted('\'', QuoteMode.OptionalForBoth)]
            public string DollarField2;
        }
    }
