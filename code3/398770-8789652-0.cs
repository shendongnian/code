    foreach(var prop in m_HttpWebRequest.GetType().GetProperties())
    {
        if(prop.CanWrite && prop.CanRead)
            prop.SetValue(m_HttpWebRequest2, prop.GetValue(m_HttpWebRequest, BindingFlags.GetProperty, null, null, null), BindingFlags.SetProperty, null, null, null);
    }
