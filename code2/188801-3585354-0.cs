    UpdateControlUsingMethod(new MethodInvoker(
        () =>
        {
            //this._prbsRxLockTime.SelectedIndexChanged -= new System.EventHandler(this._prbsRxLock_SelectedIndexChanged);
            this._prbRxLockTimeUpdatingByThread = true;
            //the code has been omitted here
            //this._prbsRxLockTime.SelectedIndexChanged += new System.EventHandler(this._prbsRxLock_SelectedIndexChanged);
            this._prbRxLockTimeUpdatingByThread = false;
        }
    ));
