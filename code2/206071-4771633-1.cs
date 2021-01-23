    public class PartitionResolver : IPartitionResolver
    {
        public void Initialize() {}
        // The key is a SID (session identifier)
        public String ResolvePartition(Object key)
        {
            return <grab your config here>;
        }
    }
