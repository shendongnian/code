    public sealed class ServerCollection : ConfigurationElementCollection,
        IEnumerable<ServerElement>
    {
        ...
        public new IEnumerator<ServerElement> GetEnumerator()
        {
            foreach (var key in this.BaseGetAllKeys())
            {
                yield return (ServerElement)BaseGet(key);
            }
        }
    }
