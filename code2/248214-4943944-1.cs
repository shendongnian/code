    class MyWrappingClass{
        [DllImport("wzcsapi.dll")]
        private static extern void WZCDeleteIntfObj(ref INTF_ENTRY Intf);
        public void useWZCDeleteIntfObj(ref INTF_ENTRY Intf){ //you may wish to use a better method name
            //you may wish to put some guards here, to check that Intf is valid before passing it to the native library.
            try{
                 WZCDeleteIntfObj( Intf );
            }catch(ExternalException e){ //try to catch more specific exception types, such as SEHException.
                //handle the exception
            }
        }
    }
