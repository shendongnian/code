    public class RunInCulture : IDisposable
    {
        CultureInfo _oldCulture;
        public RunInCulture(string culture)
            : this(CultureInfo.GetCultureInfo(culture))
        {
        }
        public RunInCulture(CultureInfo culture)
        {
            _oldCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        public static RunInCulture Invariant
        {
            get
            {
                return new RunInCulture(CultureInfo.InvariantCulture);
            }
        }
        public static RunInCulture English
        {
            get
            {
                return new RunInCulture("en-US");
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
                Thread.CurrentThread.CurrentCulture = _oldCulture;
        }
        ~RunInCulture()
        {
            Dispose(false);
        }
    }
    public class EnglishCulture : RunInCulture
    {
        public EnglishCulture()
            : base("en-US")
        {
        }
    }
