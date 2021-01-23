    public virtual TimeSpan ActualTimeSpan { get; set; }
    class TimeSpanUserType : ImmutableUserType
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            return TimeSpan.Parse((string)rs[names[0]]);
        }
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var timespan = (TimeSpan)value;
            var timeSpanstring = string.Format("{0}{1} {2}:{3}:{4}.{5}",
                timespan.ToString().Contains("-") ? "-" : "+",
                timespan.Days.ToString().Contains("-") ? timespan.Days.ToString().Substring(1).PadLeft(2, '0') : timespan.Days.ToString().PadLeft(2, '0'),
                timespan.Hours.ToString().Contains("-") ? timespan.Hours.ToString().Substring(1).PadLeft(2, '0') : timespan.Hours.ToString().PadLeft(2, '0'),
                timespan.Minutes.ToString().Contains("-") ? timespan.Minutes.ToString().Substring(1).PadLeft(2, '0') : timespan.Minutes.ToString().PadLeft(2, '0'),
                timespan.Seconds.ToString().Contains("-") ? timespan.Seconds.ToString().Substring(1).PadLeft(2, '0') : timespan.Seconds.ToString().PadLeft(2, '0'),
                timespan.Milliseconds.ToString().Contains("-") ? timespan.Milliseconds.ToString().Substring(1).PadLeft(6, '0') : timespan.Milliseconds.ToString().PadLeft(6, '0');
            NHibernateUtil.String.NullSafeSet(cmd, timeSpanstring, index);
        }
        public override Type ReturnedType
        {
            get { return typeof(TimeSpan); }
        }
        public override SqlType[] SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(8) }; }
        }
    }
    <property name="ActualTimeSpan" column="TIMESPAN_TEST" type="TimeSpanUserType"/>
