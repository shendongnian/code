    public class L10nReports//Class in DLL A
    {
        public L10nReports() //constructor
        {
        }
        //only public method is this class
        public string Supervise(object projectGroup, out string msg)
        {
            //Checks for updates of dll B and downloads it if available. And fails.
            manageUpdate();
            return SuperviseHelper(projectGroup, out msg);
        }
      
        [MethodImpl(MethodImplOptions.NoInlining)]
        public string SuperviseHelper(object projectGroup, out string msg) {
            //first instanciation of any class from dll B
            ReportEngine.ReportEngine engine = new ReportEngine.ReportEngine();
            string result = engine.Supervise(projectGroup, out msg);
            return result;
        }
