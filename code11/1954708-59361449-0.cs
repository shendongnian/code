csharp
  var result = collection.AsQueryable()
                         .SelectMany(t =>
                             t.SubCollection,
                            (t, s) => new
                             {
                                isMatch = s.DateTimeProp.Ticks < s.OtherDateTimeProp.Ticks + TimeSpan.FromMinutes(59).Ticks,
                                t.ID
                              })
                         .Where(x => x.isMatch)
                         .Select(x => x.ID)
                         .ToList();
custom date class:
csharp
    public class Date
    {
        private long ticks = 0;
        private DateTime date = new DateTime();
        public long Ticks
        {
            get => ticks;
            set { date = new DateTime(value); ticks = value; }
        }
        public DateTime DateTime
        {
            get => date;
            set { date = value; ticks = value.Ticks; }
        }
        public static implicit operator Date(DateTime dt)
        {
            return new Date { DateTime = dt };
        }
        public static implicit operator DateTime(Date dt)
        {
            if (dt == null) throw new NullReferenceException("The [Date] instance is Null!");
            return new DateTime(dt.Ticks);
        }
    }
here's a full test program:
