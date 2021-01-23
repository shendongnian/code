    class LimitHolderMap : ClassMap<LimitHolder>
    {
        public LimitHolderMap()
        {
            Map(lh => lh.Limit).CustomType<LimitUserType>();
        }
    }
    class LimitUserType : ImmutableUserType
    {
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var str = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
            if (string.IsNullOrEmpty(str))
                return null;
            else
            {
                var splitted = str.Split('|');
                return new Limit(
                    new ParsedValue(double.Parse(splitted[0]), splitted[2]),
                    new ParsedValue(double.Parse(splitted[1]), splitted[2]));
            }
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var limit = value as Limit;
            if (limit == null)
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
            else
            {
                var str = string.Concat(limit.Low.Value, '|', limit.High.Value, '|', limit.Low.Value);
                NHibernateUtil.String.NullSafeSet(cmd, str, index);
            }
        }
        public Type ReturnedType
        {
            get { return typeof(Limit); }
        }
        public SqlType[] SqlTypes
        {
            get { return new [] { SqlTypeFactory.GetString(100) }; }
        }
    }
