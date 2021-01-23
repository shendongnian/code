    doc.Close(false);
    app.Quit(false);
    if (doc != null)
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
    if (app != null)
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
    doc = null;
    app = null;
    GC.Collect();
