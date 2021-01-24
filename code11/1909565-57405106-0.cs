    public class RemovalInformation<T> : IProcessRemoval where T:class
    {
        public string TagName { get; set; }
        public T Data { get; set; }
        public Func<T, bool> RemovalCondition { get; set; }
        public bool Execute()
        {
            if (RemovalCondition != null) 
            {
                return RemovalCondition(Data);
            }
            return false;
        }
    }
