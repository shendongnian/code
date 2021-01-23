    foreach(var prop in m_HttpWebRequest.GetType().GetProperties())
    {
        if(!(prop.CanWrite && prop.CanRead))
            continue;
        var val = prop.GetValue(m_HttpWebRequest, BindingFlags.GetProperty, null, null, null);
        if (val == null)
            continue;
        prop.SetValue(m_HttpWebRequest2, val, BindingFlags.SetProperty, null, null, null);
    }
