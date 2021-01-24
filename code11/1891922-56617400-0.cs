    public class Result_Splash
    {
        public string id;
        public string version_code;
        public string version_number;
    
        public override string ToString()
        {
            // For example print the values as requested
            return $"{base.ToString()} id: {id}, version_code: {version_code}, version_number: {version_number}"
        }
    }
