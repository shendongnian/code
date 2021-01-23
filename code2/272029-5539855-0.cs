    public class EventExample
    {
        private EventHandler<ApplyEventArgs> m_evApplyAccepted;
        public event EventHandler<ApplyEventArgs> ApplyAccepted
        {
            add { m_evApplyAccepted += value; }
            remove { m_evApplyAccepted -= value; }
        }
        protected virtual void OnEventName(ApplyEventArgs e)
        {
            if (m_evApplyAccepted != null)
                m_evApplyAccepted.Invoke(this, e);
        }
        public class ApplyEventArgs : EventArgs { }
    }
