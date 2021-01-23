    public static void closeComm()
    {
        commIRToy.ClosePort();  // ERROR if commIRToy, commProj, commTV, commAV
        commProj.ClosePort();   //       are not declared static, because we're
        commTV.ClosePort();     //       in a static method and thus "outside" an
        commAV.ClosePort();     //       object instance, yet these fields are
    }                           //       declared within one.
    public static void loadAnotherRemote()
    {
        closeComm();  // this call is fine now, since `closeComm` is static,
                      // no object instance is required to call it.
    }
