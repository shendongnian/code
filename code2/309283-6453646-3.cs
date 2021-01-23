    using System;
    using System.Runtime.InteropServices;
    
    namespace Mumble {
    	[ComVisible(true)]
    	[Guid("8B72CE6C-511F-456e-B71B-ED3B3A09A03C")]
    	[ClassInterface(ClassInterfaceType.None)]
        public class Implementation : ClassLibrary2.Mumble.IExample {
            public int get_Indexer(int index) {
                return index;
        	}
        	public void set_Indexer(int index, int Value) {
        	}
    
            public string get_SomeProperty(int index) {
                return index.ToString();
            }
    
            public void set_SomeProperty(int index, string Value) {
            }
        }
    }
