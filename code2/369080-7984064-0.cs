    //example of another class
    class AnotherClass
    {
        Form1 logFileCollectorForm;
        public AnotherClass(Form1 logFileCollectorForm)
        {
            this.logFileCollectorForm = logFileCollectorForm;
        }
        public DoSomething(String newTabPage)
        {
            logFileCollectorForm.logFileCollectorTabControl.TabPages.Add(newTabPage);
        }
    }
