        interface ISixty
        {
            DateTime SixtyDaysFromNow();
        }
        public class Foo : ISixty
        {
            public DateTime SixtyDaysFromNow()
            {
                return DateTime.Now + new TimeSpan(60,0,0,0);
            }
        }
