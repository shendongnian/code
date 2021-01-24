    /// <summary>
    /// Using the same base class
    /// </summary>
    public class BaseClass
    {
        public string Property { get; set; }
    }
    public class ViewModelA : BaseClass
    {
        public string Property { get; set; }
    }
    public class ViewModelB : BaseClass
    {
        public string Property { get; set; }
    }
    /// <summary>
    /// Using the same interface
    /// </summary>
    public interface BaseInterface
    {
        string Property { get; set; }
    }
    public class ViewModelA : BaseInterface
    {
        public string Property { get; set; }
    }
    public class ViewModelB : BaseInterface
    {
        public string Property { get; set; }
    }
    /// <summary>
    /// Create a conversion mechanism. This can be done in either in ViewModelA or ViewModelB
    /// </summary>
    public class ViewModelA
    {
        public string Property { get; set; }
        public static implicit operator ViewModelA(ViewModelB model) => new ViewModelA { Property = model.Property };
        public static implicit operator ViewModelB(ViewModelA model) => new ViewModelB { Property = model.Property };
    }
    public class ViewModelB
    {
        public string Property { get; set; }
    }
