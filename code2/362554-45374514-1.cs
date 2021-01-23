    public class ImplementInform : IInform
    {
        public event EventHandler Inform;
        public void InformNow()
        {
            OnInformed(new EventArgs());
        }
        private void OnInformed(EventArgs eventArgs)
        {
            if (Inform != null)
            {
                Inform(this, eventArgs);
            }
        }
    }
