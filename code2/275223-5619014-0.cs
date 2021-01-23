    public class CallbackDemo
    {
        //Don't forget to change the calling convention accordingly
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int MFS100_CodeLineDelegate(int code, int docId, string codeline);
        public event MFS100_CodeLineDelegate MFS100_CodeLine;
        //this is one method how you keep your delegate instance being collected by GC
        private readonly MFS100_CodeLineDelegate cache;
        public CallbackDemo()
        {
            cache = OnCallBack;
        }
        protected virtual int OnCallBack(int code,int docId,string codeline)
        {
            if(this.MFS100_CodeLine!=null)
            {
                MFS100_CodeLine(code, docId, codeline);
            }
            return 0;
        }
        [DllImport("mflib.dll")]
        private static extern int mfSetEvent(int eventID, MFS100_CodeLineDelegate callsback);
        private MFS100_CodeLineDelegate myDelegate;
        public void CallSetEvent(int eventId)
        {
            mfSetEvent(eventId, this.cache);
        }
        
    }
