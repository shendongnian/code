    void Main()
    {
        using (var container = new UnityContainer())
        {
            container.RegisterFactory<IAuthoringRepository>(CreateAuthoringRepository);
    
            Console.WriteLine("debug - resolving model");
            var model = container.Resolve<Model>();
        }
    }
    
    public static IAuthoringRepository CreateAuthoringRepository(IUnityContainer container)
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
