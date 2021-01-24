    using UnityEngine;
    using UnityEngine.UI;
    using System.Runtime.InteropServices;
    using System;
    
    
    public class CallNativeCode : MonoBehaviour
    {
        [DllImport("NativeCode")]
        unsafe private static extern bool PostprocessNative(int width, int height, short* data_out);
    
        public short[] dataShortOut;
        public Text TxtOut;
    
        public void Update()
        {
            dataShortOut = new short[100];
            bool o = true;
    
            unsafe
            {
                fixed (short* ptr = dataShortOut)
                {
                    o = PostprocessNative(10, 10, ptr);
                }
            }
    
            TxtOut.text = "Function out:  " + o + " Array element 0: " + dataShortOut[0];
        }
    }
