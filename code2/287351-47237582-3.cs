    public class StateMachine<TState, TCommand>
        where TState : struct, IConvertible, IComparable
        where TCommand : struct, IConvertible, IComparable
    {
        class StateTransition<TS, TC>
            where TS : struct, IConvertible, IComparable
            where TC : struct, IConvertible, IComparable
        {
            readonly TS CurrentState;
            readonly TC Command;
            public StateTransition(TS currentState, TC command)
            {
                if (!typeof(TS).IsEnum || !typeof(TC).IsEnum)
                {
                    throw new ArgumentException("TS,TC must be an enumerated type");
                }
                CurrentState = currentState;
                Command = command;
            }
            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                StateTransition<TS, TC> other = obj as StateTransition<TS, TC>;
                return other != null
                    && this.CurrentState.CompareTo(other.CurrentState) == 0
                    && this.Command.CompareTo(other.Command) == 0;
            }
        }
        Dictionary<StateTransition<TState, TCommand>, TState> transitions;
        public TState CurrentState { get; private set; }
        protected StateMachine(TState initialState)
        {
            if (!typeof(TState).IsEnum || !typeof(TCommand).IsEnum)
            {
                throw new ArgumentException("TState,TCommand must be an enumerated type");
            }
            CurrentState = initialState;
            transitions = new Dictionary<StateTransition<TState, TCommand>, TState>();
        }
        /// <summary>
        /// Defines a new transition inside this state machine
        /// </summary>
        /// <param name="start">source state</param>
        /// <param name="command">transition condition</param>
        /// <param name="end">destination state</param>
        public void AddTransition(TState start, TCommand command, TState end)
        {
            transitions.Add(new StateTransition<TState, TCommand>(start, command), end);
        }
        public TransitionResult<TState> TryGetNext(TCommand command)
        {
            StateTransition<TState, TCommand> transition = new StateTransition<TState, TCommand>(CurrentState, command);
            TState nextState;
            if (transitions.TryGetValue(transition, out nextState))
                return new TransitionResult<TState>(nextState, true);
            else
                return new TransitionResult<TState>(CurrentState, false);
        }
        public TransitionResult<TState> MoveNext(TCommand command)
        {
            var result = TryGetNext(command);
            if(result.IsValid)
            {
                //changes state
                CurrentState = result.NewState;
            }
            return result;
        }
    }
