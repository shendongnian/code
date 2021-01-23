        Type oType = Type.GetTypeFromProgID("InDesign.Application.CS3");
        if (oType != null)
        {
            object instance = Activator.CreateInstance(oType);// or any other way you can get it
            Application app = 
                (Application)System.Runtime.InteropServices.Marshal.CreateWrapperOfType(instance, typeof(ApplicationClass));
        }
