    DateTime start = DateTime.UtcNow;
    
    //... processing ...
    
    DateTime end = DateTime.UtcNow;
    
    Syste.Diagnostics.Debug.WriteLine((end - start).ToString());
