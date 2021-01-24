    public class MyTestAssembly
    {
        public string TestName { get; set; }
        public string PassOrFail { get; set; }
        public bool Passed { get; set; }
        public string TestOutcome { get; set; }
        public string AlertLevel { get; set; }  // None, Warning, Alert
        public string AssemblyName { get; set; }
        public string AssemblyPath { get; set; }
        public string TestRunDateTime { get; set; }
        public TimeSpan testDuration;
        public string TestDuration { get; set; }
        public DateTime TestStartTime { get; set; }
        public DateTime TestStopTime { get; set; }
        public string TestResultsXmlFile { get; set; }
        public string FailureMessage { get; set; }
        public string StackTrace { get; set; }
        public string FailureStackTrace { get; set; }
        //todo: Report an error if more than one assembly exists under assemblies node
        public XmlDocument testResultXmlDocument;
        public string FailureText { get; set; }
        private XmlNodeList MyListOfTestAssembliesInResultsFile { get; set; }
        private XmlTextReader MyXmlTextReader;
        public double TestDurationSeconds;
        // And more stuff... this is only a partial example, extracted from working code.
    }
