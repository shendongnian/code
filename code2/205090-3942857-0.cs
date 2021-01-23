    public class OutputRecord
    {
        [FieldConverter(ConverterKind.Date, "ddMMyyyy" )]
        private DateTime dateInUtc:
    
        public void SetDate(DateTime date)
        {
            dateInUtc = date.ToUniversalTime();
        }
    
    }
