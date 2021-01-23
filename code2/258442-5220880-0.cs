    public class DecimalToDateUserType : IUserType
    {
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int? result = (int)NHibernateUtil.Int32.NullSafeGet(rs, names[0]);
            if ((result != null)&&(result.Value>0))
            {
                var sDate = result.Value.ToString();
                sDate = sDate.Insert(6, "/").Insert(4, "/");
                var ci = new CultureInfo("en-US");
    
                return Convert.ToDateTime(sDate, ci);
            }
            return (DateTime.MinValue);
        }
    
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
    
            if ((DateTime)value == DateTime.MinValue)
                value = 0;
    
            int convertedValue = 0;
            int.TryParse(((DateTime)value).ToString("yyyyMMdd"), out convertedValue);
    
            value = convertedValue;
    
            NHibernateUtil.String.NullSafeSet(cmd, value, index);
        }
    
        public object DeepCopy(object value)
        {
            if (value == null) return null;
            return (value);
        }
    
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
    
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
    
        public SqlType[] SqlTypes
        {
            get
            {
                SqlType[] types = new SqlType[1];
                types[0] = new SqlType(DbType.Decimal);
                return types;
            }
        }
    
        public Type ReturnedType
        {
            get { return typeof(DateTime); }
        }
    
        public bool IsMutable
        {
            get { return false; }
        }
    
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null) return false;
            return x.Equals(y);
        }
    
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    }
