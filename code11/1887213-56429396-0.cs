    public interface IElements
    {
        IEnumerable<ElementA> ReadOnlyElements { get; }
    }
    public class ContainerA : IElements
    {
        public List<ElementA> Elements { get; set; }
        IEnumerable<ElementA> IElements.ReadOnlyElements => Elements;
    }
    public class ContainerB : IElements
    {
        public List<ElementB> Elements { get; set; }
        IEnumerable<ElementA> IElements.ReadOnlyElements => Elements;
    }
