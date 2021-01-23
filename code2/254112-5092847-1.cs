    private readonly object _bufLock;
    class EMClass{
        public static void LockedClear(this ArrayList a){
            lock(_bufLock){
                a.Clear();
            }
        }
    }
