    public class Asynchronizer
    {
        public readonly ActionDelegate DoAction;
        public delegate void ActionDelegate(Action action);
        public Asynchronizer()
        {
            m_Lock = new object();
            DoAction = new ActionDelegate(ActionWrapper);
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
