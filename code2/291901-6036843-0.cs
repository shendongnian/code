    public class LocalizableModel
    {
        private Dictionary<string,string> labels = new Dictionary<string,string> ();
        public string LocalizedLabel
        {
            get { return this.labels[Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName]; }
        }
    }
