    StreamWriter sw = fiobj.AppendText();
    try
    {
        sw.WriteLine("mohan!");
    }
    finally
    {
        if (sw != null)
        {
            sw.Close();
            ((IDisposable)sw).Dispose();
        }
    }
