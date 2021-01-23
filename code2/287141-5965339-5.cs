    public static bool IsElevated {
       get {
             return new WindowsPrincipal
                (WindowsIdentity.GetCurrent()).IsInRole
                (WindowsBuiltInRole.Administrator);
           }
    }
