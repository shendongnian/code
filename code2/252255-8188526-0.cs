    [XmlRoot("config")]
    public class Configuration
    {
        [XmlElement("appSettings")]
        public AppSettings ApplicationSettings
        {
            get;
            set;
        }
        [XmlElement("execSettings")]
        public ExecSettings ExecutionSettings
        {
            get;
            set;
        }
    }
    [XmlRoot("appSettings")] // Not really necessary this xmlroot
    public class AppSettings
    {
        [XmlElement("DEV")]
        public EnvironmentSetting Development
        {
            get;
            set;
        }
        [XmlElement("STAGE")]         
        public EnvironmentSetting Staging
        {
            get;
            set;
        }
        [XmlElement("PROD")]
        public EnvironmentSetting Production
        {
            get;
            set;
        }
    }
    [XmlRoot("execSettings")] // Not really necessary this xmlroot
    public class ExecSettings
    {
        [XmlElement("DEV")]
        public ExecutionSetting Development
        {
            get;
            set;
        }
        [XmlElement("STAGE")]         
        public ExecutionSetting Staging
        {
            get;
            set;
        }
        [XmlElement("PROD")]
        public ExecutionSetting Production
        {
            get;
            set;
        }
    }
    public class EnvironmentSetting
    {
        [XmlElement("INDIR")]
        public string InDirectory
        {
           get;
           set;
        } 
        [XmlElement("OUTDIR")]
        public string OutDirectory
        {
           get;
           set;
        } 
        [XmlElement("LOGDIR")]
        public string LogDirectory
        {
           get;
           set;
        }
    }
    public class ExecutionSetting
    {
        [XmlElement("FILTER")]
        public string Filter 
        {
           get;
           set;
        } 
        [XmlElement("RETENTION")]
        public string Retention
        {
           get;
           set;
        } 
    }
