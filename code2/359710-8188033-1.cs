        const string ValidatingMatrixEventKey = "ValidatingMatrix";
        public event System.ComponentModel.CancelEventHandler ValidatingMatrix
        {
            add { this.Events.AddHandler(ValidatingMatrixEventKey, value); }
            remove { this.Events.RemoveHandler(ValidatingMatrixEventKey, value); }
        }
        protected bool OnValidatingMatrix()
        {
            var handler = this.Events[ValidatingMatrixEventKey] as System.ComponentModel.CancelEventHandler;
            if (handler != null)
            {
                // prepare event args
                var e = new System.ComponentModel.CancelEventArgs(false);
                // call the event handlers (an event can have multiple event handlers)
                handler(this, e);
                // if any event handler changed the Cancel property to true, then validation failed (return false)
                return !e.Cancel;
            }
            // there were no event handlers, so validation passes by default (return true)
            return true;
        }
        private void MyLogic()
        {
            if (this.OnValidatingMatrix())
            {
                // validation passed
            }
            else
            {
                // validation failed
            }
        }
