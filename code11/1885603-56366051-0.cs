    public class DateConverter : ITypeConverter
    {
        private readonly string _dateFormat;
        public DateConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!string.IsNullOrEmpty(text))
            {
                DateTime dt;
                DateTime.TryParseExact(text, _dateFormat,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dt);
                if (IsValidSqlDateTime(dt))
                {
                    return dt;
                }
            }
            return null;
        }
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ObjectToDateString(value, _dateFormat);
        }
        public string ObjectToDateString(object o, string dateFormat)
        {
            if (o == null) return string.Empty;
            DateTime dt;
            if (o is DateTime)
            {
                dt = (DateTime)o;
                return dt.ToString(dateFormat);
            }
            else
                return string.Empty;
        }
        public bool IsValidSqlDateTime(DateTime? dateTime)
        {
            if (dateTime == null) return true;
            DateTime minValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
            DateTime maxValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString());
            if (minValue > dateTime.Value || maxValue < dateTime.Value)
                return false;
            return true;
        }
    }
and use :
using (var writer = new StreamWriter(_checksumsFilePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.TypeConverterCache.RemoveConverter<DateTime>();
                csv.Configuration.TypeConverterCache.RemoveConverter<DateTime?>();
                csv.Configuration.TypeConverterCache.AddConverter<DateTime?>(new DateConverter("MM/dd/yyyy hh:mm:ss.fff"));
                csv.Configuration.TypeConverterCache.AddConverter<DateTime>(new DateConverter("MM/dd/yyyy hh:mm:ss.fff"));
                csv.WriteRecords(_checksums.Values.ToList());
            }
