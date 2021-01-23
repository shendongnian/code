    public class Asynchronizer
    {
        public readonly Action<Action> DoAction;
        public Asynchronizer()
        {
            m_Lock = new object();
            DoAction = new Action<Action>(ActionWrapper);
        }
        private object m_Lock;
        private void ActionWrapper(Action action)
        {
            lock (m_Lock)
            {
                action();
            }
        }
    }
