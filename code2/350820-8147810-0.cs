    var resp = (HttpWebResponse)m_responseRequest.EndGetResponse(m_responseCallbackAsyncResult);
    byte[] buf = new byte[resp.Headers.ToString().Length];
    buf = resp.Headers.ToString().ToCharArray();
    Debug.WriteLine(buf);
      
