    public abstract class EventInvocatorParametersBase
        <TEventInvocatorParameters, TEventArgs>
        where TEventArgs : EventArgs
        where TEventInvocatorParameters :
            EventInvocatorParametersBase<TEventInvocatorParameters, TEventArgs>
    {
        protected EventInvocatorParametersBase(
            EventHandler<TEventArgs> eventHandler,
            Func<Exception, bool> exceptionHandler,
            Func<TEventArgs, bool> breakCondition)
        {
            EventHandler = eventHandler;
            ExceptionHandler = exceptionHandler;
            BreakCondition = breakCondition;
        }
        protected EventInvocatorParametersBase(
            EventHandler<TEventArgs> eventHandler)
            : this(eventHandler, e => false, e => false)
        {
        }
        public Func<TEventArgs, bool> BreakCondition { get; set; }
        public EventHandler<TEventArgs> EventHandler { get; set; }
        public Func<Exception, bool> ExceptionHandler { get; set; }
        public TEventInvocatorParameters Until(
            Func<TEventArgs, bool> breakCondition)
        {
            BreakCondition = breakCondition;
            return (TEventInvocatorParameters)this;
        }
        public TEventInvocatorParameters WithExceptionHandler(
            Func<Exception, bool> exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
            return (TEventInvocatorParameters)this;
        }
        public ConfiguredEventInvocatorParameters<TEventArgs> With(
            object sender, 
            TEventArgs eventArgs)
        {
            return new ConfiguredEventInvocatorParameters<TEventArgs>(
                EventHandler, ExceptionHandler, BreakCondition,
                sender, eventArgs);
        }
    }
    public class EventInvocatorParameters<T> :
        EventInvocatorParametersBase<EventInvocatorParameters<T>, T>
        where T : EventArgs
    {
        public EventInvocatorParameters(EventHandler<T> eventHandler)
            : base(eventHandler)
        {
        }
    }
    public class ConfiguredEventInvocatorParameters<T> :
        EventInvocatorParametersBase<ConfiguredEventInvocatorParameters<T>, T>
        where T : EventArgs
    {
        public ConfiguredEventInvocatorParameters(
            EventHandler<T> eventHandler,
            Func<Exception, bool> exceptionHandler,
            Func<T, bool> breakCondition, object sender,
            T eventArgs)
            : base(eventHandler, exceptionHandler, breakCondition)
        {
            EventArgs = eventArgs;
            Sender = sender;
        }
        public ConfiguredEventInvocatorParameters(EventHandler<T> eventHandler,
                                                  object sender,
                                                  T eventArgs)
            : this(eventHandler, e => false, e => false, sender, eventArgs)
        {
        }
        public T EventArgs { get; private set; }
        public object Sender { get; private set; }
    }
    public static class EventExtensions
    {
        public static EventInvocatorParameters<TEventArgs> Until<TEventArgs>(
            this EventHandler<TEventArgs> eventHandler,
            Func<TEventArgs, bool> breakCondition)
            where TEventArgs : EventArgs
        {
            return new EventInvocatorParameters<TEventArgs>(eventHandler).
                Until(breakCondition);
        }
        public static EventInvocatorParameters<TEventArgs> 
            WithExceptionHandler<TEventArgs>(
                this EventHandler<TEventArgs> eventHandler,
                Func<Exception, bool> exceptionHandler)
            where TEventArgs : EventArgs
        {
            return
                new EventInvocatorParameters<TEventArgs>(eventHandler).
                    WithExceptionHandler(exceptionHandler);
        }
        public static ConfiguredEventInvocatorParameters<TEventArgs>
            With<TEventArgs>(
                this EventHandler<TEventArgs> eventHandler, object sender,
                TEventArgs eventArgs)
            where TEventArgs : EventArgs
        {
            return new ConfiguredEventInvocatorParameters<TEventArgs>(
                eventHandler, sender, eventArgs);
        }
    }
