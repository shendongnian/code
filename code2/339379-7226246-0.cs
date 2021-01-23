    Object _lockOnMe = new Object();
    Object _iMightBeNull;
    public void DoSomeKungFu() {
        if (_iMightBeNull == null) {
            lock (_lockOnMe) {
                if (_iMightBeNull == null) {
                    _iMightBeNull = ...  whatever ...;
                }
            }
        }
    }
