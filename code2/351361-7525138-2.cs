    /* Option 1, implicitly calling Dispose */
    using (StreamWriter writer = new StreamWriter(filename)) { 
       // do something
    } 
    /* Option 2, explicitly calling Close */
    StreamWriter writer = new StreamWriter(filename)
    try {
        // do something
    }
    finally {
        writer.Close();
    }
