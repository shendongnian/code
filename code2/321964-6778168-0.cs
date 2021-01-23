    public class DataClass
    {
        //....
        public string ResourcePolicyName
        {
            get { return ResourcePolicy != null ? ResourcePolicy.Name : ResourcePolicyAvailSystemsLVI.m_nullString; }
        }
        public string AgentVersionString
        {
            get
            {
                if (AgentVersion == null || AgentVersion.Equals("0.0.0.0"))
                {
                    return ResourcePolicySystemsControl.m_nullVersion;
                }
                return AgentVersion;
            }
        }
    }
