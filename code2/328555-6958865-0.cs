    using System;
    using System.Runtime.InteropServices;
    
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IThingsIWantToExpose {
        void mumble();
        // etc..
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MyComClass : SomeBaseClass, IThingsIWantToExpose {
        // Actual implementation of the methods
        public void mumble() { }
        // etc, plus everything else that you want to do in the class
        //...
    }
