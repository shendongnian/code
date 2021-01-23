    public class Settings
    {
        // The real property
        public TimeSpan StartWorkDay { get; set; }
        // The conversion property
        public string StartWorkDayString
        {
            get
            {
                return StartWorkDay.ToString();
                // (or use .ToString("...") to format it)
            }
            set
            {
                StartWorkDay = TimeSpan.Parse(value);
                // (or use TryParse() to avoid throwing exceptions)
            }
        }
    }
