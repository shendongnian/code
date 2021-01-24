using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var handlerType = typeof(IHandleKey);
		var classes = typeof(Program).Assembly // you can get them however you want
			.GetTypes()
		    .Where(p => handlerType.IsAssignableFrom(p) && p.IsClass)
			.Select(t => (IHandleKey)Activator.CreateInstance(t)) // or use IoC to resolve them...
			.ToArray();
		
		while(true) {
			var key = Console.ReadLine(); // or however you get your input
			var handler = classes.FirstOrDefault(x => x.Key == key);
			
			if (handler == null) {
				Console.WriteLine("Couldn't find a handler for " + key);
			} else {
				handler.Handle();
			}
		}
	}
}
public interface IHandleKey 
{
	String Key { get; }
	void Handle();	
}
public class Banana : IHandleKey 
{
	public String Key {	get { return "u"; } }
	public void Handle() 
	{
		Console.WriteLine("I did banana work");
	}
}
This way if you need to develop a new feature, all you need to add is one class that contains information about valid key and the implementation logic.
Likewise, if you don't want to have the instances ready to handle the command, you can split this and have an attribute describing the key on the type, like so:
using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var handlerType = typeof(IHandleKey);
		var classes = typeof(Program).Assembly
			.GetTypes()
		    .Where(p => handlerType.IsAssignableFrom(p) && p.IsClass && p.GetCustomAttributes(typeof(KeyHandlerAttribute), false).Count() > 0) // note we're checking for attribute here. This can be optimised.
			.ToArray();
		
		while(true) {
			var key = Console.ReadLine(); // or however you get your input
			var concreteType = classes.FirstOrDefault(x => ((KeyHandlerAttribute)(x.GetCustomAttributes(typeof(KeyHandlerAttribute), false).First())).Key == key);
			
			if (concreteType == null) {
				Console.WriteLine("Couldn't find a handler for " + key);
			} else {
				var handler = (IHandleKey)Activator.CreateInstance(concreteType); // or use IoC to resolve them...
				handler.Handle();
			}
		}
	}
}
public interface IHandleKey 
{
	void Handle();	
}
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class KeyHandlerAttribute: Attribute 
{
	public String Key { get; set; }
}
[KeyHandler(Key = "u")]
public class Banana : IHandleKey 
{
	public void Handle() 
	{
		Console.WriteLine("I did banana work");
	}
}
**Update** Here's the updated program listing using the second variant and implementing shared state and event-based communication.
To be honest, I find this rather trivial, so feel free to ask any questions as i'm not sure what might appear more confusing and what not...
using System;
using System.Linq;
using System.Collections.Generic;
namespace Whatever
{
    public class Program
    {
        public static void Main()
        {
            // This part belongs to IoC as a Singleton
            var state = new State();
            // This part belongs to IoC as scoped services
            var handlerType = typeof(IHandleKey);
            var dict = new Dictionary<String, Object>();
            foreach (var type in typeof(Program).Assembly
                .GetTypes()
                .Where(p => handlerType.IsAssignableFrom(p) && p.IsClass))
            {
                var attributes = type.GetCustomAttributes(typeof(KeyHandlerAttribute), false);
                if (attributes.Any())
                {
                    var attribute = (KeyHandlerAttribute)attributes.First();
                    var handlr = (IHandleKey)Activator.CreateInstance(type);
                    handlr.RegisterEvent(state);
                    dict.Add(attribute.Key, handlr);
                }
            }
            // Main routine here
            while (true)
            {
                var key = Console.ReadLine(); // or however you get your input
                var handler = dict.ContainsKey(key) ? (IHandleKey)dict[key] : null;
                if (handler == null)
                {
                    Console.WriteLine("Couldn't find a handler for " + key);
                }
                else
                {
                    handler.Handle();
                }
            }
        }
    }
    // This class allows us to share state.
    public class State : ISharedState
    {
        // As required by the question, this is an event.
        public event EventHandler StateChanged;
        public void RaiseStateChange(object sender)
        {
            this.StateChanged.Invoke(sender, new EventArgs());
        }
    }
    // This makes our Handlers unit testable.
    public interface ISharedState
    {
        event EventHandler StateChanged;
        void RaiseStateChange(object sender);
    }
    // Familiar interface -> note how we have a 'register event' method now.
    // We could instead just use a constructor on the HandlerBase. This is really dealer's choice now.
    public interface IHandleKey
    {
        void Handle();
        void RegisterEvent(ISharedState state);
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class KeyHandlerAttribute : Attribute
    {
        public String Key { get; set; }
    }
    // To avoid boilerplate in our handlers for registering/unregistering events we have a base handler class now.
    public abstract class HandlerBase: IHandleKey
    {
        protected ISharedState _state;
        public abstract void Handle();
        public void RegisterEvent(ISharedState state)
        {
            this._state = state;
            this._state.StateChanged += OnStateChanged;
        }
        public abstract void OnStateChanged(object sender, EventArgs e);
        
        ~HandlerBase()
        {
            this._state.StateChanged -= OnStateChanged;
        }
    }
    
    // Actual handlers...
    [KeyHandler(Key = "u")]
    public class Banana : HandlerBase
    {
        public override void Handle()
        {
            Console.WriteLine("I did banana work");
            this._state.RaiseStateChange(this);
        }
        public override void OnStateChanged(object sender, EventArgs e)
        {
            if (sender != this) // optional, in case we don't want to do this for self-raised changes
            {
                Console.WriteLine("State changed inside Banana handler");
            }
        }
    }
    [KeyHandler(Key = "c")]
    public class Cheese : HandlerBase
    {
        public override void Handle()
        {
            Console.WriteLine("I did cheese work");
            this._state.RaiseStateChange(this);
        }
        public override void OnStateChanged(object sender, EventArgs e)
        {
            if (sender != this) // optional, in case we don't want to do this for self-raised changes
            {
                Console.WriteLine("State changed inside cheese handler");
            }
        }
    }
}
