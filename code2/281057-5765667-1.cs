    // http://msdn.microsoft.com/en-us/library/aa288459(VS.71).aspx
    // delegates are a lot like function pointers and events "appear" to be a lot like delegates.
    // in a sense, a delegate is a function pointer class.  below is an example declaration
    // of a delegate with an int return value, and two parameters (bool, string)
    public delegate int MyDelegate(bool abool, string astring);
    // delegates behind the scenes are actually of the System.MulticastDelegate type, and therefore
    // can have multiple invocations.
    // see http://msdn.microsoft.com/en-us/library/system.multicastdelegate.aspx
    class DelegatesAndEvents
    {
        // delegates can also be defined inside classes
        public delegate void AnotherDelegate();
        // Delegates can be instantiated just like any variable or field
        public AnotherDelegate DelegateInstance;
        public DelegatesAndEvents()
        {
            // add method/delegate to the invocation list
            DelegateInstance += Method;
            // or another syntax
            DelegateInstance += new AnotherDelegate(Method);
            // remove a method/delegate to the invocation list
            DelegateInstance -= Method;
            // or the more formal syntax
            DelegateInstance -= new AnotherDelegate(Method);
            // set the invocation list to a single method/delegate
            DelegateInstance = Method;
            // or the more formal syntax
            DelegateInstance = new AnotherDelegate(Method);
            // to clear a delegate, assign it to null:
            DelegateInstance = null;
            // for all the previous operators, its very important to note
            // that they instantiate a new MulticastDelegate in the process.
            // this means that every add (+=) or remove(-=) generates a new
            // MulticastDelegate.  Look at the following scenario:
            DelegateInstance = Method;
            // invoking a will call Method
            AnotherDelegate a = DelegateInstance;
            DelegateInstance += AnotherMethod;
            // now, invoking a will still only invoke Method, while
            // invoking DelegateInstance will invoke both Method
            // and AnotherMethod.
            // NOTE NOT BEST PRACTICE SEE BELOW
            a(); // invokes Method
            DelegateInstance(); // invokes Method and AnotherMethod
            // The main importance of this fact deals with thread safety
            // when invoking delegates.  When invoking a delegate, you
            // should always do a null-check before invocation to avoid
            // an exception:
            // NOTE NOT BEST PRACTICE SEE BELOW
            if (a != null)
            {
                a();
            }
            // the problem with the above code is that if another thread removes
            // Method from a, after the null check, trying to invoke a will throw
            // an exception.  To get around this, since we stated before that the
            // remove operation recreates the MulticastDelegate, assigning the
            // delegate to a temporary delegate before doing the null check, and
            // then invoking that temporary delegate should avoid threading problems
            //**************************************************************
            // NOTE THIS IS BEST PRACTICE FOR INVOKING A DELEGATE/EVENT
            // This is thread-safe
            AnotherDelegate aCopy = a;
            if (aCopy != null)
            {
                aCopy();
            }
            //**************************************************************
        }
        // NOTE there is a way to avoid having to worry about null checking, with only
        // a small overhead.  assigning a delegate/event to an initial no-op function will
        // simplify how it is invoked:
        public AnotherDelegate ThirdDelegate = delegate { }; // this assigns a no-op delegate
        // using this method, you'll be able to call the delegate without checking for
        // null or use a temporary variable.  this of course is only true if no code
        // sets ThirdDelegate to null anywhere.
        public void Method()
        {
            // Delegates can be instantiated just like any variable or field
            MyDelegate x = AFunction; // shorthand way of creating a delegate from an actual function
            x = new MyDelegate(AFunction); // the more formal way of creating a delegate
            // if a delegate hasn't been assigned anything, trying to call it will throw an exception
            // not really necessary here though since we just assigned it
            if (x != null)
            {
                int somevalue = x(false, "10");
            }
        }
        public void AnotherMethod()
        {
            // Do Nothing
        }
        public int AFunction(bool somebool, string somestring)
        {
            if (somebool)
            {
                return 1;
            }
            int avalue;
            if (int.TryParse(somestring, out avalue))
            {
                return avalue;
            }
            return 0;
        }
        // EVENTS
        // events are types as delegates but avoid a couple of issues with
        // instantiating delegates as members of a class.  unlike delegates
        // events can only be created within a class or struct (ie not as
        // a standalone type in a namespace).  to create an event, add the
        // event keyword:
        public event AnotherDelegate AnotherEvent;
        // the above is actually the shorthand way of instantiating an event
        // the full way is below:
        private MyDelegate someEvent;
        public event MyDelegate SomeEvent
        {
            add
            {
                someEvent += value;
            }
            remove
            {
                someEvent -= value;
            }
        }
        // EXPLANATION OF HOW AN EVENT DIFFERS FROM A DELEGATE
        // events are actually similar to properties in that they wrap a
        // non-public delegate.  this prohibits an external source from
        // doing two things that most likely aren't desired:
        // external code can't invoke the delegate
        //    external code can't do: classInstance.SomeEvent(...parameters...);
        // external code can't set the delegate
        //    external code can't do: classInstance.SomeEvent = somedelegate;
        // this effectively makes an event something that occurs within class, and
        // controlled by the class, but can be subscribed to by external code.
        // events usually derive from the EventHandler or EventHandler<T> delegates
        // which have the following definitions:
        // void EventHandler(object sender, EventArgs e)
        // void EventHandler<T>(object sender, T e)
        // the common way to use these is to always send the class instance that
        // raised the event, as well as some event arguments that contain more
        // information about the event.  see below for an example of extending
        // EventArgs.
        public event EventHandler<TakeOffEventArgs> TakeOff;
        public void PerformTakeOff()
        {
            EventHandler<TakeOffEventArgs> takeOffTemp = TakeOff;
            if (takeOffTemp != null)
            {
                takeOffTemp(this, new TakeOffEventArgs("Spaceship", double.MaxValue));
            }
        }
    }
    public class TakeOffEventArgs : EventArgs
    {
        public TakeOffEventArgs(string aircraft, double speed)
        {
            Aircraft = aircraft;
            Speed = speed;
        }
        public string Aircraft { get; set; }
        public double Speed { get; set; }
    }
