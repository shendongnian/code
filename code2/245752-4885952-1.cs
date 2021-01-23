    public class RandomReadableStringSource : DatasourceBase<string>
    {
        private readonly char[] _Vocals = new char[] { 'a', 'e', 'i', 'o', 'u' };
        private readonly char[] _Consonants = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v', 'w' };
        private Random _Random;
        private int _Minimum;
        private int _Maximum;
        public RandomReadableStringSource()
            : this(20)
        { }
        public RandomReadableStringSource(int max)
            : this(5, max)
        { }
        public RandomReadableStringSource(int min, int max)
        {
            if (min <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum must be greater zero.");
            }
            if (min > max)
            {
                throw new ArgumentOutOfRangeException("minimum must be less or equal maximum.");
            }
            _Random = new Random();
            _Minimum = min;
            _Maximum = max;
        }
        public override string Next(IGenerationSession session)
        {
            var length = _Random.Next(_Minimum, _Maximum);
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                var array = i % 2 == 0 ? _Consonants : _Vocals;
                sb.Append(array[_Random.Next(array.Length)]);
            }
            return sb.ToString();
        }
    }
    public class DateTimeUniqueSource : DatasourceBase<DateTime>
    {
        private Random _Random;
        private DateTime _LastDateTime;
        public DateTimeUniqueSource()
            : this(new DateTime(1900, 1, 1))
        { }
        public DateTimeUniqueSource(DateTime startdate)
        {
            if (startdate == null)
            {
                throw new ArgumentNullException("startdate");
            }
            _Random = new Random();
            _LastDateTime = startdate;
        }
        public override DateTime Next(IGenerationSession session)
        {
            _LastDateTime = _LastDateTime.AddHours(_Random.NextDouble() * 1000);
            return _LastDateTime;
        }
    }
