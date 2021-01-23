    public class ApplicationContext : IDisposable
    {
        private Form mainForm;
        // ...
        public ApplicationContext(Form mainForm)
        {
            this.MainForm = mainForm;
        }
        // ...
    }
