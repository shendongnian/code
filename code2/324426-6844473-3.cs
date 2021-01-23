    abstract class AgentVersionBase {
        public string AgentVersion {
            get {
                return m_agentVersion;
            }
        }
        private string m_agentVersion = string.Empty;
    }
    public class AgentVersion : AgentVersionBase {
        public string aMethod() {
            return base.AgentVersion;
        }
    }
  
