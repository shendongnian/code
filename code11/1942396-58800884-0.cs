    void SetMobileDataEnabled(bool enabled)
    {
        if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.L) {
            Console.WriteLine ("Device does not support mobile data toggling.");
            return;
        }
    
        try {
            if (Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.KitkatWatch 
                && Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Gingerbread) {
                Android.Net.ConnectivityManager conman = (Android.Net.ConnectivityManager)GetSystemService (ConnectivityService);
                Java.Lang.Class conmanClass = Java.Lang.Class.ForName (conman.Class.Name);
                Java.Lang.Reflect.Field iConnectivityManagerField = conmanClass.GetDeclaredField ("mService");
                iConnectivityManagerField.Accessible = true;
                Java.Lang.Object iConnectivityManager = iConnectivityManagerField.Get (conman);
                Java.Lang.Class iConnectivityManagerClass = Java.Lang.Class.ForName (iConnectivityManager.Class.Name);
                Java.Lang.Reflect.Method setMobileDataEnabledMethod = iConnectivityManagerClass.GetDeclaredMethod ("setMobileDataEnabled", Java.Lang.Boolean.Type);
                setMobileDataEnabledMethod.Accessible = true;
    
                setMobileDataEnabledMethod.Invoke (iConnectivityManager, enabled);
            }
    
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Gingerbread) {
    
                TelephonyManager tm = (TelephonyManager)GetSystemService (Context.TelephonyService);
    
                Java.Lang.Class telephonyClass = Java.Lang.Class.ForName (tm.Class.Name);
                Java.Lang.Reflect.Method getITelephonyMethod = telephonyClass.GetDeclaredMethod ("getITelephony");
                getITelephonyMethod.Accessible = true;
    
                Java.Lang.Object stub = getITelephonyMethod.Invoke (tm);
                Java.Lang.Class ITelephonyClass = Java.Lang.Class.ForName (stub.Class.Name);
    
                Java.Lang.Reflect.Method dataConnSwitchMethod = null;
                if (enabled) {
                    dataConnSwitchMethod = ITelephonyClass
                        .GetDeclaredMethod ("disableDataConnectivity");
                } else {
                    dataConnSwitchMethod = ITelephonyClass
                        .GetDeclaredMethod ("enableDataConnectivity");   
                }
    
                dataConnSwitchMethod.Accessible = true;
                dataConnSwitchMethod.Invoke (stub);
            } 
        } catch (Exception ex) {
            Console.WriteLine ("Device does not support mobile data toggling.");
        }
    }
