    public class Memento<T>
    {
        public Memento(T startState)
        {
            this.State = startState;
            this.OriginalState = startState;
        }
        public T State { get; set; }
        public T OriginalState { get; }
        public void RestorOriginalState()
        {
            State = OriginalState;
        }
    }
