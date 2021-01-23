    public abstract class State
    {
       protected StateFactory _factory;
       protected IStateUser _context;
    
       public State(StateFactory factory, IStateUser context)
       {
          _factory = factory;
          _context = context;
       }
    
       protected void TransitionTo<T>(Func<T> creator) where T : State
       {
           State state = _factory.GetOrCreate<T>(creator);
           _context.CurrentState = state;
       }
    
       public abstract void MoveNext();
       public abstract void MovePrevious();
    }
    
    public class State1 : State
    {
       public State1(StateFactory factory, IStateUser context)
                : base(factory, context)
       {
       }
    
       public override void MoveNext()
       {
          TransitionTo<State2>(() => new State2(_factory, _context));
       }
    
       public override void MovePrevious()
       {
          throw new InvalidOperationException();
       }
    }
    
    public class State2 : State
    {
       public State2(StateFactory factory, IStateUser context)
                : base(factory, context)
       {
       }
    
       public override void MoveNext()
       {
          TransitionTo<State3>(() => new State3(_factory, _context)); //State 3 is omitted for brevity
       }
    
       public override void MovePrevious()
       {
          TransitionTo<State1>(() => new State1(_factory, _context));
       }
    }
    
    public interface IStateUser
    {
       State CurrentState { get; set; }
    }
    
    public class Client : IStateUser
    {
    
       public Client()
       {
          var factory = new StateFactory();
          var first = new State1(factory, this);
          CurrentState = factory.GetOrCreate<State1>(() => first);
       }
    
       public void MethodThatCausesTransitionToNextState()
       {
          CurrentState.MoveNext();
       }
    
       public void MethodThatCausesTransitionToPreviousState()
       {
          CurrentState.MovePrevious();
       }
    
       public State CurrentState
       {
          get;
          set;
       }
    }
    
    public class StateFactory
    {
        private Dictionary<string, State> _states = new Dictionary<string, State>();
    
        public State GetOrCreate<T>(Func<T> creator) where T : State
        {
            string typeName = typeof(T).FullName;
    
            if (_states.ContainsKey(typeName))
                return _states[typeName];
    
            T state = creator();
            _states.Add(typeName, state);
    
            return state;
        }
    }
