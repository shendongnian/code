    public class Controller : MonoBehaviour
    {
    
        public class Action
        {
            public enum InputType
            {
                Impulse,
                Hold,
                Toggle
            };
    
            public string name;
            public InputType inputType;
            public KeyCode binding;
                    ...
                }
    
        public virtual Action[] actions { get; }
        public bool[] actionStates;
    
        public Controller()
        {
            actionStates = new bool[actions.Length];
        }
    
    }
