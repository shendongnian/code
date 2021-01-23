     internal class Memento: IMemento
        {
            private object _state;
    
            public void SetState(object state)
            {
                _state = state;
            }
    
            public object GetState()
            {
                return _state;
            }
        }
