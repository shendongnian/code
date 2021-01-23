        private Dictionary<string, EventHandler> TestEvents { get; }
        public event EventHandler TestEvent
        {
            add
            {
                string name = value.GetType().FullName;
                if (!TestEvents.ContainsKey(name))
                {
                    TestEvents.Add(name, value);
                }
            }
            remove
            {
                string name = value.GetType().FullName;
                if (TestEvents.ContainsKey(name))
                {
                    TestEvents.Remove(name);
                }
            }
        }
