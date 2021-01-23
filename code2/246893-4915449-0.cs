    public class StringToDateTimeConverter: ITypeConverter<string, DateTime>
    {
        public DateTime Convert(ResolutionContext context)
        {
            object objDateTime = context.SourceValue;
            DateTime dateTime;
            if (objDateTime == null)
            {
                return default(DateTime);
            }
            
            if (DateTime.TryParse(objDateTime.ToString(), out dateTime))
            {
                return dateTime;
            }
            return default(DateTime);
        }
    }
