public class MqttServiceEventListener // first name that popped into my head
{
    private readonly MQTTService _mqttService;
    public MqttServiceEventListener(MQTTService mqttService)
    {
        _mqttService = mqttService;
        
        // add event handlers
    }
}
Register this class in `ConfigureServices`. This is because you might want to inject other dependencies into this class which are needed to handle events. As long as everything is registered with the `IServiceCollection` you'll be able to resolve this whole class from the container.
Next you'll need an instance of `MqttServiceEventListener`. It could be owned by a static class or by t, but if it's not going to be instantiated in response to web requests then then another solution is just create an instance at startup and have it listen for events. There are a few ways to do this, and preferences will differ.
You could do this:
    public static class MqttServiceEventListenerExtensions
    {
        private static MqttServiceEventListener _eventListener;
        public static void UseMqttServiceEventListener(this IApplicationBuilder app)
        {
            if (_eventListener == null) return; //or throw an InvalidOperationException
            _eventListener = app.ApplicationServices.GetService<MqttServiceEventListener>();
        }
    }
Now, in `Startup.Configure`, call this:
    app.UseMqttServiceEventListener();
A big caveat to this is that I don't know what the lifetime of your event listener needs to be or what the lifetime of its dependencies need to be. Using a single instance like this could be all you need, or it could cause problems. 
**If classes registered as singletons are bad in your scenario:**
A similar option might be to skip the static instance of an event listener and just register a class that handles events (or even different classes to handle different events), like this:
    public class MqttServiceEventHandler
    {
        public void MqttServerClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            // handle the event
        }
    }
Same thing - register the event handlers with the `IServiceProvider` container. If they need to have shorter lifetimes you can make them transient.
Now, in your extension class, do this instead:
    public static class MqttServiceEventListenerExtensions
    {
        private static MQTTService _mqttService; // likely unnecessary
        public static void UseMqttServiceEventListener(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            // This is registered as a singleton, so there's only going to be on instance.
            _mqttService = serviceProvider.GetService<MQTTService>();
            // Add event handlers that resolve the needed class and pass the
            // event to it.
            _mqttService.ClientDisconnected += (sender, eventArgs) =>
            {
                var handler = serviceProvider.GetService<MqttServiceEventHandler>();
                handler.MqttServerClientConnected(sender, eventArgs);
            };
        }
    }
And same thing in `Startup.Configure`: `app.UseMqttServiceEventListener();`
First you're resolving `MQTTService`, which you registered as a singleton, so the service provider will always return the same instance. It's debatable whether you need to actually store a reference to it in the class. You can always remove the `_mqttService`, resolve `MQTTService` as a local variable, and add event handlers to that.
Next, you're adding event handlers that resolve a class needed to handle the event and then pass the event args to it. Again, this requires that all of these classes be registered up front. But that's good, because that means you can inject more dependencies into those classes if needed, and so on. 
It also gives you the flexibility to create different classes to handle different events if one class is going to be too big. The extension method can resolve one class to handle one event, another to handle another event, and so on. And lifetime isn't an issue because the event handler classes aren't resolved until you need them. They can be transient or singleton according to your needs.
