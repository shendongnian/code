    public static void OnTimerEvent(object source, EventArgs e)
    {
    m_streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
    m_streamWriter.Flush();
    }
