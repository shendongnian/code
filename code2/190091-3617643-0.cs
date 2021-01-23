    public IEnumerator<object> GetEnumerator()
    {    
        var property = typeof(Student).GetProperty(PropertyToIterate.ToString());
        for (int i = 0; i < m_Students.Count; ++i)
        {
            yield return (string)property.GetValue(m_Students[i], null);
        }            
    }
