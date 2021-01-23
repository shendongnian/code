    abstract class AgentVersionBase
    {
        public abstract int AgentVersion { 
            get
            {
                return m_agentVersion;
            }
        }
        private string m_agentVersion = null;
    }
    public class AgentVersion : AgentVersionBase
    {
        public int aMethod() {
             return base.AgentVersion;
        }
    }
  
