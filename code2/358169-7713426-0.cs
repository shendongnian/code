    public interface IActivatable
    {
        bool IsActive { get; set; }
    }
    public class ClassA : IActivatable
    {
        public bool IsActive{ get; set;}
    }
    public class ClassB : IActivatable
    {
        public bool IsActive { get; set;}
    }
    public static class Ext
    {
        public static IEnumerable<T> IsActive<T>(this IEnumerable<T> collection, bool isActive) where T : IActivatable
        {
            return collection.Where(x => x.IsActive == isActive);
        }
    }
