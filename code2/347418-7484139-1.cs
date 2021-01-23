    public virtual TimeSpan ActualTimeSpan { get; set; }
    class TimeSpanUserType : ImmutableUserType
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            // Need to do some formatting of TimeSpanTest before it can be parsed
            return TimeSpan.Parse((string)rs[names[0]]);
        }
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var timespan = (TimeSpan)value;
            var duration = timespan.Duration();
            var timeSpanstring = string.Format("{0}{1} {2}:{3}:{4}.{5}",
                (timespan.Ticks < 0) ? "-" : "+",
                duration.Days.ToString().PadLeft(2, '0'),
                duration.Hours.ToString().PadLeft(2, '0'),
                duration.Minutes.ToString().PadLeft(2, '0'),
                duration.Seconds.ToString().PadLeft(2, '0'),
                duration.Milliseconds.ToString().PadLeft(6, '0'));
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
