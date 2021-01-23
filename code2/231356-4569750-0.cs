    public void Dispose()  
    {   
            doc.Close(false); 
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(doc);
            doc = null; 
            GC.Collect();
    }
