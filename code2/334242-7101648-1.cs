     public class Caretaker
        {
            private Dictionary<int,IMemento> _mementos = new Dictionary<int,IMemento>();
            public void AddMemento(int tag, IMemento memento)
            {
                _mementos.Add(tag, memento);
            }
    
            public IMemento GetMemento(int tag)
            {
    
                if (_mementos.ContainsKey(tag))
                {
                    return _mementos[tag];
                }
    
                return null;
            }
        }
