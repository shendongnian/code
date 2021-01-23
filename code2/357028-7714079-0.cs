    public interface IUnityComponent
    {
      IEnumerable<IMefComponent> MefComponents { get; }
    }
    public interface IMefComponent
    {
      string Name { get; }
    }
