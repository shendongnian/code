    public class Screen
    {
        public event EventHandler Closed;
        public event EventHandler ScreenRemoved;
        protected virtual void OnClosed()
        {
            if (Closed != null)
            {
                Closed.Invoke(this, EventArgs.Empty);
            }
            OnScreenRemoved();
        }
        protected virtual void OnScreenRemoved()
        {
            if (ScreenRemoved != null)
            {
                ScreenRemoved.Invoke(this, EventArgs.Empty);
            }
        }
    }
