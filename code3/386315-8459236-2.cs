    public class ApplicationContext : IDisposable
    {
        public Form MainForm
        {
            get { /* ... */ }
            set { /* ... */ }
        }
        public ApplicationContext(Form mainForm)
        {
            this.MainForm = mainForm;
        }
        // ...
    }
