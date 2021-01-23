    public class MeetingsGenerator
    {
        public static IList<Meeting> CreateMeeting(int count)
        {
            var factory = AutoPocoContainer.Configure(x =>
            {
                x.Conventions(c => { c.UseDefaultConventions(); });
                x.Include<Meeting>()
                    .Setup((c => c.CreatedBy)).Use<FirstNameSource>()
                    .Setup(c => c.StartDate).Use<DefaultRandomDateSource>
                                      (DateTime.Parse("21/May/2012"), 
                                        DateTime.Parse("21/May/2011"))
                    .Setup(c => c.EndDate).Use<MeetingEndDateSource>(0, 8);
            });
            return factory.CreateSession().List<Meeting>(count).Get();
        }
    }
    public class Meeting
    {
        public string CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class MeetingEndDateSource : DatasourceBase<DateTime>
    {
        private int mMin;
        private int mMax;
        private Random mRandom = new Random(1337);
        public MeetingEndDateSource(int min, int max)
        {
            mMin = min;
            mMax = max;
        }
        public override DateTime Next(IGenerationContext context)
        {
            var node = (TypeGenerationContextNode)((context.Node).Parent);
            var item = node.Target) as Meeting;
            if (item == null)
                return DateTime.Now;
            return item.StartDate.AddHours(mRandom.Next(mMin, mMax + 1));
        }
    }
    class DefaultRandomDateSource : DatasourceBase<DateTime>
    {
        private DateTime _MaxDate { get; set; }
        private DateTime _MinDate { get; set; }
        private Random _random = new Random(1337);
        public DefaultRandomDateSource(DateTime MaxDate, DateTime MinDate)
        {
            _MaxDate = MaxDate;
            _MinDate = MinDate;
        }
        public override DateTime Next(IGenerationContext context)
        {
            var tspan = _MaxDate - _MinDate;
            var rndSpan = new TimeSpan(0 
                                      , _random.Next(0, (int)tspan.TotalMinutes)
                                      , 0);
            return _MinDate + rndSpan;
        }
    }
