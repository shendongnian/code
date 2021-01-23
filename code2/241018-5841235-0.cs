    IISVersionManagerLibrary.IISVersionManager mgr = new IISVersionManagerLibrary.IISVersionManagerClass();
    IISVersionManagerLibrary.IIISVersion ver = mgr.GetVersionObject("7.5", IISVersionManagerLibrary.IIS_PRODUCT_TYPE.IIS_PRODUCT_EXPRESS);
        
    object obj1 = ver.GetPropertyValue("expressProcessHelper");
        
    IISVersionManagerLibrary.IIISExpressProcessUtility util = obj1 as IISVersionManagerLibrary.IIISExpressProcessUtility;
