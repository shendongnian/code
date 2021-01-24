    using (var objLocks = new DisposableList<DistributedLock>())
    {
        // Obtain locks
        foreach (var seatToRemove in seatsToRemove)
        {
            objLocks.Add(seatToRemove.GetModifyLock());
        }
        // Perform locked actions
        foreach (var seatToRemove in seatsToRemove)
        {
            seatToRemove.HardDelete();
        }
    }
