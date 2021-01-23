    abstract class AgentVersionBase
    {
        public abstract int AgentVersion    { get; }
    }
    public class AgentVersion : AgentVersionBase
    {
        public override int iAgentVersion
        {
            get
            {
                return m_agentVersion;
            }
        }
    }
    private string m_agentVersion = null;
