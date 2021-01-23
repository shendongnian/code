    [Serializable]
    class MyCustomClipboardClass
    {
        List<string> m_lstTexts = new List<string>();
    
        public void AddText(string str)
        {
            m_lstTexts.Add(str);
        }
    }
