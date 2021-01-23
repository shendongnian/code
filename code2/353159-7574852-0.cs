    void SomeMethodThatMightNeedToWait() {
        lock(lockObj) {
            if(needSomethingSpecialToHappen) {
                Monitor.Wait(lockObj);
                // ^^^ this ***releases*** the lock (however many times needed), and
                // enters the pending-queue; when *another* thread "pulses", it
                // enters the ready-queue; when the lock is *available*, it
                // reacquires the lock (back to as many times as it held it 
                // previously) and resumes work
            }
            // do some work, happy that something special happened, and
            // we have the lock
        }
    }
    void SomeMethodThatMightSignalSomethingSpecial() {
        lock(lockObj) {
            // do stuff
            Monitor.PulseAll(lockObj);
            // ^^^ this moves **all** items from the pending-queue to the ready-queue
            // note there is also Pulse(...) which moves a *single* item
        }
    }
