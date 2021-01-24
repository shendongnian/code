    // No "Empty" (re-)declaration here
    public class ElapsedEventArgs : EventArgs {   
        private DateTime signalTime;
        
        internal ElapsedEventArgs(int low, int high) {        
            long fileTime = (long)((((ulong)high) << 32) | (((ulong)low) & 0xffffffff));
            this.signalTime = DateTime.FromFileTime(fileTime);                        
        }
    
        public DateTime SignalTime {
            get {
                return this.signalTime;
            }
        }
    }
