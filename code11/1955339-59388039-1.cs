    public class MyListener : YourButtonListener
    {
        // Now since I used a virtual property above
        // I can either keep it ad a simple 
        // standard setter and getter 
        // or I can implement an own additional functionality like e.g.
        private bool _active;
        public override bool Active
        {
            get => _active;
            set
            {
                _active = value;
                // Here I can put whatever I like to happen when this is set
                Debug.Log("I just got " + (value ? "activated" : "deactivated"));
            }
        }
    }
