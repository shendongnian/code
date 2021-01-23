    class Frobber
    {
        State state;
        ...
        void M()
        {
             ...
             try
             {
                 oldstate = state;
                 state = newstate;
                 this.DoIt();
             }
             finally
             {
                 state = oldstate;
             }
        }
