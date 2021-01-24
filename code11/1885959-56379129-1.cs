    public class DateHandler : ITypeHandler
    {
        public object Parse(Type destinationType, object value)
        {
            return new Date() { MyDate = (DateTime)value };
        }
    
        public void SetValue(IDbDataParameter parameter, object value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = ((Date)value).MyDate;
        }
    }
    
