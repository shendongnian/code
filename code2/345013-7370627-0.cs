    public abstract class BindableBase
    {
        private readonly Dictionary<string, Action> m_boundMethods =
            new Dictionary<string, Action>();
        protected Dictionary<string, Action> BoundMethods
        {
            get { return m_boundMethods; }
        }
        public void Bind(string method, Action action)
        {
            if (!m_boundMethods.ContainsKey(method))
                m_boundMethods.Add(method, null);
            m_boundMethods[method] += action;
        }
        public void Unbind(string method, Action action)
        {
            if (m_boundMethods.ContainsKey(method))
            {
                m_boundMethods[method] -= action;
                if (m_boundMethods[method] == null)
                    m_boundMethods.Remove(method);
            }
        }
    }
