    using UnityEngine;
    using System.Runtime.InteropServices;
    class SomeScript : MonoBehaviour {
       #if UNITY_IPHONE
   
       // On iOS plugins are statically linked into
       // the executable, so we have to use __Internal as the
       // library name.
       [DllImport ("__Internal")]
       #else
       // Other platforms load plugins dynamically, so pass the name
       // of the plugin's dynamic library.
       [DllImport ("PluginName")]
    
       #endif
       private static extern float FooPluginFunction ();
       void Awake () {
          // Calls the FooPluginFunction inside the plugin
          // And prints 5 to the console
          print (FooPluginFunction ());
       }
    }
