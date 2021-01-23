    abstract class Parent
    {
        public Parent()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(this.DoStuff));
        }
    
        private void DoStuff()
        {
            // stuff, could also be abstract or virtual
        }
    }
