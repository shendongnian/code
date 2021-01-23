    IBindCtx bc; 
        CreateBindCtx(0, out bc); 
 
    IRunningObjectTable rot; 
    bc.GetRunningObjectTable(out rot); 
    // EXCEPTION: pdwRegister is *always* 65536, an invalid value! 
    rot.Revoke(pdwRegister);       
