    void Main()
    {
        using (var container = new UnityContainer())
        {
            container.RegisterType<IAuthoringRepository>(
                new InjectionFactory(c => CreateAuthoringRepository()));
    
            Console.WriteLine("debug - resolving model");
            var model = container.Resolve<Model>();
        }
    }
    
    public IAuthoringRepository CreateAuthoringRepository()
    {
        Console.WriteLine("debug - calling factory");
        return new AuthoringRepository
            { Identity = WindowsIdentity.GetCurrent() };
    }
    
    public class Model
    {
        public Model(IAuthoringRepository repository)
        {
            Console.WriteLine(
                "Constructing model with repository identity of "
                + repository.Identity);
        }
    }
    
    public interface IAuthoringRepository
    {
        IIdentity Identity { get; }
    }
    
    public class AuthoringRepository : IAuthoringRepository
    {
        public IIdentity Identity { get; set; }
    }
