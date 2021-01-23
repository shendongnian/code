    public interface IDependency
    {
        IResource Resource { get; }
        DependencyType Type { get; }
    }
    public interface IResource
    {
        IEnumerable<IDependency> Dependencies { get; set; }
    }
