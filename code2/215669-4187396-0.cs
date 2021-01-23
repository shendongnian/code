    // Define event args if you have additional
    // information to pass to your event handlers
    public class MassChangedEventArgs : EventArgs
    {
        public MassChangedEventArgs(int oldMass)
        {
            OldMass = oldMass;
        }
        public int OldMass { get; private set; }
    }
    public class SomeObject
    {
        // There's a generic event handler delegate that can be
        // used so you only need to define the event arguments.
        public event EventHandler<MassChangedEventArgs> MassChanged;
        // Convenience method to raise the event
        protected void OnMassChanged(MassChangedEventArgs e)
        {
            if (MassChanged != null)
                MassChanged(this, e);
        }
        public int Mass
        {
            get
            {
                return mass;
            }
            set
            {
                // Your checks here
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Mass", "Mass can't be zero or negative");
                // Should only raise the event if the new value is different
                if (value != mass)
                {
                    // Change the mass
                    MassChangedEventArgs e = new MassChangedEventArgs(mass);
                    mass = value;
                    // Raise the event
                    OnMassChanged(e);
                }
            }
        }
        private int mass;
    }
