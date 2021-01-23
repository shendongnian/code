    class MyWrappingClass{
        [DllImport("wzcsapi.dll")]
        private static extern void WZCDeleteIntfObj(ref INTF_ENTRY Intf);
        public void useWZCDeleteIntfObj(ref INTF_ENTRY Intf){
            //you may wish to put some guards here, to check that Intf is valid before passing it to the native library.
            try{
                 WZCDeleteIntfObj( Intf );
            }catch(Exception e){ //you want to catch more specific exception types. Catching Exception is not ideal, and is used for this example only
                //handle the exception
            }
        }
    }
