    public class TimeType : BaseImmutableUserType<TimeSpan>
    {
        // this is taken from the source of NHibernate.Type.TimeAsTimeSpanType
        private static readonly DateTime BaseDateValue = new DateTime(1753, 01, 01);
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var val = NHibernateUtil.TimeAsTimeSpan.NullSafeGet(rs, names[0]);
            if (val == null)
                return null;
            var dt = DateTime.Parse(val.ToString());
            return new TimeSpan(0, dt.Hour, dt.Minute, dt.Second);
        }
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            //var obj = (TimeSpan)value;  // we can't use TimeSpan here but need to use DateTime
            // this is taken from the source of NHibernate.Type.TimeAsTimeSpanType
            DateTime date = BaseDateValue.AddTicks(((TimeSpan)value).Ticks);
            ((IDbDataParameter)cmd.Parameters[index]).Value = date;
        }
        public override SqlType[] SqlTypes
        {
            get
            {
                return new[] { NHibernate.SqlTypes.SqlTypeFactory.Time };
            }
        }
    }
