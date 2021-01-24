       private void MonitorSameThreadTest() {
        var obj = new object();
        lock (obj) {
            // Lock obtained. Must exit once to release.
            // No *other* thread can obtain a lock on obj
            // until this (outermost) "lock" completes.
            lock (obj) {
                // Same thread can actually enter again
                var lockTaken = false;
                try {
                    Monitor.Enter(obj, ref lockTaken);
                    // Same thread can actually enter again
                    // We've *re-entered* lock again.
                }
                finally {
                    if (lockTaken) Monitor.Exit(obj);
                    // Must exit twice to release.
                }
            }
            // Must exit once to release.
        }
        // the lock allowing other threads to obtain it.
    }
