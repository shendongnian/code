    interface IStateMachine<TIn, TOut, TState>
    {
      TOut Next(TIn input);
      TState State { get; }
      bool IsHalted { get; }
    }
