    class HoldIntegerUnsynchronized {
        int buffer;
        object syncLock = new object();
        bool goodToRead = false;
        bool goodToWrite = true;
        public int Buffer {
           get {
               lock (syncLock) {
                   while (!goodToWrite)
                       Monitor.Wait(syncLock);
                   buffer = value;
                   goodToWrite = false;
                   goodToRead = true;
                   Monitor.Pulse(syncLock);
               }
           }
           set {
               lock (syncLock) {
                   while (!goodToRead)
                       Monitor.Wait(syncLock);
                   int toReturn = buffer;
                   goodToWrite = true;
                   goodToRead = false;
                   Monitor.Pulse(syncLock);
                   return toReturn;
               }
           }
        }
    }
