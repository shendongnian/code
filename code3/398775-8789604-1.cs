    public interface IPlugin {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        void Init();
    }
