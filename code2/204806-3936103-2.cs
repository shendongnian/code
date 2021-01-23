    private void ReleaseObject(object obj)
    {
        if (obj != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
            GC.Collect();
        }
    }
