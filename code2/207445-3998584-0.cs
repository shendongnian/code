        public event EventHandler MyEvent
        {
            add
            {
                Events.AddHandler("MyEvent", value);
            }
            remove
            {
                Events.RemoveHandler("MyEvent", value);
            }
        }
