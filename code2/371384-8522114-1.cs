    [FileHelpers.DelimitedRecord(",")]
    public class rec
    {
        public int id;
        [FileHelpers.FieldConverter(typeof(NullableDecimalConverter))]
        public decimal? mydecimal;
    }
