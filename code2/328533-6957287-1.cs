    StreamWriter sw = fiobj.AppendText();
    try
    {
        sw.WriteLine("mohan!");
    }
    finally
    {
        if (sw != null)
        {
            ((IDisposable)sw).Dispose();
        }
    }
