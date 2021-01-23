    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    namespace ClassLibrary1 {
        [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IFoo {
            int property {
                [Description("prop")]
                get;
                [Description("prop")]
                set;
            }
        }
    }
