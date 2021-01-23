    class State
    {
        public State (string stateId, int timeZoneOffset)
        {
           StateId = stateId;
           TimeZoneOffSet = timeZoneOffset;
        }
    
        public String StateId {get;set;}
        public int TimeZoneOffest {get;set;}
    }
    
    public class StatesAndTerritories
    {
        List<State> _states = new List<State>
        public StatesAndTerritories ()
        {
          //_state.Add state information here
          _state.Add(new State("AZ", -6); ......
    
        }
        public IEnumerable<State> GetStates (){
         return _state;
        }
    }
