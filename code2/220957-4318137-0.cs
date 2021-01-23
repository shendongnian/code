    public class MyDelegateContainer 
    { 
        Dictionary<string, Action<int>> m_Container =
            new Dictionary<string, Action<int>>(); 
     
        public void Add(string key, Action<int> del) 
        { 
            m_Container.Add(key, del);
        } 
     
        public bool Remove(string key) 
        { 
            return m_Container.Remove(key); 
        } 
    }
