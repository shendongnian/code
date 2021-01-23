    // at the begining of the code before uses
    #if DUMMY
    #undef NOT_DUMMY
    #else
    #define NOT_DUMMY
    #endif
            
    // somewhere in class
    [Conditional("NOT_DUMMY")]
    public static void ShowDebugStringNOTDUMMY(string s)
    {
      Debug.Print("ShowDebugStringNOTDUMMY");
    }
    
    
    [Conditional("DUMMY")]
    public static void ShowDebugStringDUMMY(string s)
    {
      Debug.Print("ShowDebugStringDUMMY");
    }
