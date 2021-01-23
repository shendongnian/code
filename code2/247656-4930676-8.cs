    class TimeComparer : IEqualityComparer<Action>
    {
        public bool Equals(Action a, Action b)
        {
            return a.TimeOfAction == b.TimeOfAction;
        }
    
        public int GetHashCode(Action obj)
        {
            return obj.TimeOfAction.GetHashCode();
        }
    }
