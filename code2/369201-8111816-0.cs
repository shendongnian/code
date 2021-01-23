    //  this is a sample program using the pattern i am recommending
    //  I'm pretty sure this is what you wanted your code to look like? 
    public class Program
    {
        public static void Main()
        {
            var request = new HPCGetConfig();
            request.RequestComplete += HandleConfigRequestCompleted;
            request.SendAsync();
        }
        static void HandleConfigRequestCompleted(object sender, RequestCompleteEventArgs<HPCGetConfig> e)
        {
            var request = e.Request;
            // do something with the request
        }
    }
    //  the non-generic event args class 
    public abstract class RequestCompleteEventArgs : EventArgs
    {
        public abstract Type RequestType { get; }
        public abstract object RequestObject { get; set; }
    }
    // the generic event args class
    public class RequestCompleteEventArgs<T> : RequestCompleteEventArgs
    {
        private T m_Request;
        public T Request
        {
            get { return m_Request; }
            set { m_Request = value; }
        }
        public override Type RequestType
        {
            get { return typeof(T); }
        }
        public override object RequestObject
        {
            get { return Request; }
            set
            {
                if (!(value is T))
                {
                    throw new ArgumentException("Invalid type.", "value");
                }
                m_Request = (T)value;
            }
        }
    }
    //  the non-generic interface
    public interface IHPCRequest
    {
        event EventHandler<RequestCompleteEventArgs> RequestComplete;
    }
    //  the generic base class
    public abstract class HPCRequest<T> : IHPCRequest 
        where T : HPCRequest<T>
    {
        //  this sanitizes the event handler, and makes it callable 
        //  whenever an event handler is subscribed to the non-generic 
        //  interface
        private static EventHandler<RequestCompleteEventArgs<T>> ConvertNonGenericHandler(EventHandler<RequestCompleteEventArgs> handler)
        {
            return (sender, e) => handler(sender, e);
        }
        //  this object is for a lock object for thread safety on the callback event
        private readonly object Bolt = new object();
        //  This determines whether the send method should raise the completed event.
        //  It is false by default, because otherwise you would have issues sending the request asynchronously
        //  without using the SendAsync method.
        public bool AutoRaiseCompletedEvent { get; set; }
        //  This is used to ensure that RequestComplete event cannot fire more than once
        public bool HasRequestCompleteFired { get; private set; }
        //  declare the generic event
        public event EventHandler<RequestCompleteEventArgs<T>> RequestComplete;
        
        //  explicitly implement the non-generic interface by wiring the the non-generic
        //  event handler to the generic event handler
        event EventHandler<RequestCompleteEventArgs> IHPCRequest.RequestComplete
        {
            add { RequestComplete += ConvertNonGenericHandler(value); }
            remove { RequestComplete -= ConvertNonGenericHandler(value); }
        }
        //  I'm not 100% clear on your intended functionality, but this will call an overrideable send method
        //  then raise the OnRequestCompleted event if the AutoRaiseCompletedEvent property is set to 'true'
        public void Send()
        {
            SendRequest((T)this);
            if(AutoRaiseCompletedEvent) 
            {
                OnRequestCompleted((T)this);
            }
        }
        public void SendAsync()
        {
            // this will make the event fire immediately after the SendRequest method is called
            AutoRaiseCompletedEvent = true;
            new Task(Send).Start();
        }
        //  you can make this virtual instead of abstract if you don't want to require that the Request 
        //  class has the Send implementation
        protected abstract void SendRequest(T request);
        //  this raises the RequestCompleted event if it is the first call to this method.  
        //  Otherwise, an InvalidOperationException is thrown, because a Request can only 
        //  be completed once
        public void OnRequestCompleted(T request)
        {
            bool invalidCall = false;
            Exception handlerException = null;
            if (HasRequestCompleteFired)
                invalidCall = true;
            else
            {
                lock(Bolt)
                {
                    if(HasRequestCompleteFired)
                    {
                        invalidCall = true;
                    }
                    else
                    {
                        if (RequestComplete != null)
                        {
                            // because you don't want to risk throwing an exception
                            // in a locked context
                            try
                            {
                                RequestComplete(this, new RequestCompleteEventArgs<T> { Request = request });
                            }
                            catch(Exception e)
                            {
                                handlerException = e;
                            }
                        }
                        HasRequestCompleteFired = true;
                    }
                }
            }
            if(invalidCall)
            {
                throw new InvalidOperationException("RequestCompleted can only fire once per request");
            }
            if(handlerException != null)
            {
                throw new InvalidOperationException("The RequestComplete handler threw an exception.");
            }
        }
    }
    // a sample concrete implementation
    public class HPCGetConfig : HPCRequest<HPCGetConfig>
    {
        protected override void SendRequest(HPCGetConfig request)
        {
            // do some configuration stuff
        }
    }
