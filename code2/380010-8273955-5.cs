    public class NewClass
    {
        private NotifyDelegate m_Notifier;
        public void Notify(string Msg)
        {
            m_Notifier.Invoke(Msg);
        }
        public NewClass(NotifyDelegate oNotifier)
        {
            m_Notifier = oNotifier;
        }
    }
