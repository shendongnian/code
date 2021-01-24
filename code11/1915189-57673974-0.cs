RegisterMultipleTypesToContainer(container, typeof(IPipeline));
I suppose this is what Scutor does, but there was no scutor at the time so have to use Reflection, and then just subscribe.... 
private void RegisterMultipleTypesToContainer(IContainer container, Type type)
{
  var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                         .Where(x => 
                               x.FullName.StartsWith("MyAssembly", StringComparison.Ordinal))SelectMany(x => x.GetTypes());
   var types = allTypes.Where(x => type.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract).ToList();
            foreach (var concreteTypes in types)
            {
                var genericTypes = concreteTypes.GetInterfaces().Where(x => x != type).ToList();
                foreach (var genericType in genericTypes)
                {
                    container.Register(genericType, concreteTypes, Reuse.Singleton);
                    var pipeline = container.Resolve(genericType) as IPipeline;
                    pipeline.Subscribe();
                }
            }
        }
 public class HelloPipeline :
        BasePipeline<HelloPipeline.Message>
    {
    IBusService _bus;
    HelloPipeline(IBusService bus){
     _bus = bus;
     }
    private Task ExecuteAsync(String channel, ) { }
       public void Subscribe()
        {
            _bus.SubscribeAsync<T>(this.GetType().Name, this.ExecuteAsync);
        }
    }
Just checked old code but still works, hope it gives you an idea, but I thinks what you are trying to achieve is the same as I did, but with other tools
