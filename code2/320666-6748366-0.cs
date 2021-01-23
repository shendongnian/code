        public event EventHandler SomeEvent
        {
            add
            {
                // Perform some code before the subscription.
                // Add the event.
                SomeEvent += value;
                // Perform some code after the subscription;
            }
            remove
            {
                // Perform some code before the subscription.
                // Remove the event.
                SomeEvent -= value;
                // Peroform some code after the subscription.
            }
        }
