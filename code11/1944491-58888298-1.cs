    public class NovFactory
    {
        public INov Create()
        {
            return new Nov
            {
                Violations = Enumerable.Empty<Violation>();
            }
        }
    }
    
    public interface INov
    {
        IEnumerable<Violation> Violations { get; }
    }
    
    public class Nov : INov
    {
        public IEnumerable<Violation> Violations { get; set; }
    }
