    public class Service<T>  where T : IEntity
    {
        public Dictionary<string, Configuration<T>> Configurations = new Dictionary<string, Configuration<T>>();
        public void RegisterConfiguration(string name, Configuration<T> configuration) 
        {
            if (Configurations.ContainsKey(name))
                return;
            Configurations.Add(name, configuration); //Error: Unable to convert Configuration<T> to Configuration<IEntity>
        }
    }
