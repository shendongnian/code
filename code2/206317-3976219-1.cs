    [Export(typeof(IAdaptedStuffUser))]
    public class AdaptedStuffUser : IAdaptedStuffUser
    {
       [Import] // instead of [ImportMany(typeof(IAdaptedStuff)))]
       public IAdaptedStuffProvider AdaptedStuffProvider { private get; set; }
       public void DoSomething()
       {
          foreach (var adaptedStuff in AdaptedStuffProvider.GetAdaptedStuff())
          {
             ...
          }
       }
    }
    
    [Export(typeof(IAdaptedStuffProvider))]
    public AdaptedStuffProvider : IAdaptedStuffProvider
    {
       [ImportMany]
       public IEnumerable<IStuff> StuffToAdapt { get; set; }
    
       public IEnumerable<IAdaptedStuff> GetAdaptedStuff()
       {
          return StuffToAdapt.Select(x => new Adapter(x));
       }
    }
