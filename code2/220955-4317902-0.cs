    public class MyDelegateContainer
    {
        List<Action<int>> m_Container = new List<Action<int>>();
    
        public Action Add(Action<int> del)
        {
            m_Container.Add(del);
            return new Action(() =>
            {
                m_Container.Remove(del);
            });
        }
    }
