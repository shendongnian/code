    public static class StarSigns
    {
        private static StarSign[] _starSigns;
        static StarSigns()
        {
            var names = new[]
            {
                "Aquarius", "Pisces", "Aries", "Taurus",
                "Gemini", "Cancer", "Leo", "Virgo",
                "Libra", "Scorpio", "Sagittarius", "Capricorn", 
            };
            var days = new[]
            {
                20, 18, 20, 20,
                21, 21, 22, 23,
                23, 23, 22, 22,
            };
            _starSigns = (from i in Enumerable.Range(0, 12)
                          let name = names[i]
                          let startMonth = i + 1
                          let startDay = days[i]
                          let endDay = days[(i + 1) % 12] - 1
                          select new StarSign(name, startMonth, startDay, endDay)).ToArray();
        }
        public static StarSign GetFor(DateTime birthDate)
        {
            return (from starSign in _starSigns
                    let startDate = starSign.GetStartDate(birthDate.Year)
                    let endDate = starSign.GetEndDate(birthDate.Year)
                    where startDate <= birthDate
                    where endDate >= birthDate
                    select starSign).Single();
        }
        public static StarSign GetFor(int birthMonth, int birthDay)
        {
            return GetFor(new DateTime(2010, birthMonth, birthDay));
        }
    }
    public class StarSign
    {
        public StarSign(string name, int startMonth, int startDay, int endDay)
        {
            this.Name = name;
            this.StartMonth = startMonth;
            this.StartDay = startDay;
            this.EndDay = endDay;
        }
        public string Name { get; private set; }
        public int StartDay { get; private set; }
        public int EndDay { get; private set; }
        public int StartMonth { get; private set; }
        public int EndMonth
        {
            get
            {
                return this.StartMonth + 1;
            }
        }
        public DateTime GetStartDate(int year)
        {
            return new DateTime(year, this.StartMonth, this.StartDay);
        }
        public DateTime GetEndDate(int year)
        {
            var nextStart = new DateTime(year, (this.StartMonth % 12) + 1, this.EndDay + 1);
            return nextStart.Subtract(TimeSpan.FromTicks(1));
        }
        public string Period
        {
            get
            {
                var startDate = this.GetStartDate(2010);
                var endDate = this.GetEndDate(2010);
                var template = "{0:MMMM dd} - {1:MMMM dd}";
                return String.Format(template, startDate, endDate);
            }
        }
        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Period);
        }
    }
