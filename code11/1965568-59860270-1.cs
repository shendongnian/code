    public class ComponentB : Component
    {
        [Browsable(true)]
        public new event EventHandler Disposed
        {
            add { base.Disposed += value; }
            remove { base.Disposed -= value; }
        }
        // ... rest of properties ...
     }
