    // Non-recursive version -- state engine
    //rta.Push (State.Exit);
    //parameters.Push (new Move (n, Needle.A, Needle.B, Needle.Temp));
    //MoveTower3 ();
    enum State { Init, Call1, Call2, Rtrn, Exit }
    {  
      ...
      #region Non-recursive version -- state engine
      static void MoveTower3 ()
      {
        State s = State.Init;
        Move m = null;
        while (true)
          switch (s)
          {
            case State.Init:
              m = moveStack.Pop ();
              s = (m.n <= 0) ? State.Rtrn : State.Call1;
              break;
            case State.Call1:
              rta.Push (State.Call2); // where do I want to go after the call is finished
              moveStack.Push (m);    // save state for second call
              moveStack.Push (new Move (m.n-1, m.start, m.temp, m.finish)); // parameters
              s = State.Init;
              break;
            case State.Call2:
              m = moveStack.Pop ();  // restore state from just before first call
              Console.WriteLine (m);
              rta.Push (State.Rtrn);
              moveStack.Push (new Move (m.n-1, m.temp, m.finish, m.start));
              s = State.Init;
              break;
            case State.Rtrn:
              s = rta.Pop ();
              break;
            case State.Exit:
              return;
          }
      }
      #endregion
      #region Enumeration
      static IEnumerable<Move> GetEnumerable (int n)
      {
        Stack<Move> moveStack = new Stack<Move> ();
        Stack<State> rta = new Stack<State> (); // 'return addresses'
        rta.Push (State.Exit);
        moveStack.Push (new Move (n, Needle.A, Needle.B, Needle.Temp));
        State s = State.Init;
        Move m = null;
        while (true)
          switch (s)
          {
            case State.Init:
              m = moveStack.Pop ();
              s = (m.n <= 0) ? State.Rtrn : State.Call1;
              break;
            case State.Call1:
              rta.Push (State.Call2); // where do I want to go after the call is finished
              moveStack.Push (m);    // save state for second call
              moveStack.Push (new Move (m.n-1, m.start, m.temp, m.finish)); // parameters
              s = State.Init;
              break;
            case State.Call2:
              m = moveStack.Pop ();  // restore state from just before first call
              yield return m;
              rta.Push (State.Rtrn);
              moveStack.Push (new Move (m.n-1, m.temp, m.finish, m.start));
              s = State.Init;
              break;
            case State.Rtrn:
              s = rta.Pop ();
              break;
            case State.Exit:
              yield break;
          }
      }
      #endregion
    }
