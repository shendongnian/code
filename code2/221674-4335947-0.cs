    public struct DealImportRequest
    {
        private DealRequestBase _dr;
        private int _irc;
        public DealRequestBase DealReq
        {
          get { return _dr; }
          set { _dr = value; }
        }
        public int ImportRetryCounter
        {
          get { return _irc; }
          set { _irc = value; }
        }
        /* Note we aren't allowed to do this explicitly - this is didactic code only and isn't allowed for real*/
        public DealImportRequest()
        {
            this._dr = default(DealRequestBase); // i.e. null or default depending on whether this is reference or value type.
            this._irc = default(int); // i.e. 0
        }
        public DealImportRequest(DealRequestBase drb)
        {
            this.DealReq = drb;
            this.ImportRetryCounter = 0;
        }
    }
