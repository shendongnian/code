    public class ComponentA : Component
    {
        public event EventHandler ComponentBTimerBTick
        {
            add => ComponentB.TimerB.Tick += value;
            remove => ComponentB.TimerB.Tick -= value;
        }
        ...
    }
