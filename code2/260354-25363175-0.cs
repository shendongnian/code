    interface IWhatever
    {
      void Trace(string strWhatever);
    }
    
    class CWhatever : IWhatever
    {
        public void Trace(string strWhatever)
        {
    #if TRACE
           // Your trace code goes here
    #endif
        }
    }
