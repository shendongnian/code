    public class Container
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Status { get; private set; }
        public static List<Container> containers = new List<Container>();
        public Container() { }
        public Container(string id, String containerName, String version, String status)
        {
            Id = id;
            Name = containerName;
            Version = version;
            Status = status;
        }
        public static void AddContainerToList(Container container)
        {
            containers.Add(container);
        }
        public static List<Container> getContainerList()
        {
            return containers;
        }
    }
