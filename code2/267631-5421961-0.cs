    public class L10nReports//Class in DLL A
    {
        public L10nReports() //constructor
        {
        }
    
 
        //only public method is this class
        public string Supervise(object projectGroup, out string msg)
        {
           manageUpdate();
           return SuperviseImpl(projectGroup, out msg);
        }
        private string SuperviseImpl(object projectGroup, out string msg)
        {
            //first instanciation of any class from dll B
            ReportEngine.ReportEngine engine = new ReportEngine.ReportEngine();
    
            string result = engine.Supervise(projectGroup, out msg);
    
            return result;
        }
