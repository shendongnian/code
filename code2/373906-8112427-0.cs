    public static void DebugFormat(string fmt, params object[] p)
    {
         Debug.WriteLine(fmt, p); // this will select the right overload 
                                  // ... due to typeof(p)==object[]
    }
    // ...
    DebugFormat("Put text here: {0}", myString, null/*dummy*/);
    int myNumber = 1;
    DebugFormat("Put number here: {0}", myNumber);
