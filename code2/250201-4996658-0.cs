    public bool PrepaymentCalculating { 
        get {
            if (_PrepaymentCalculating != null ) {
                return (bool)_PrepaymentCalculating;
            } else {
                return somethingElse; // bool
            }
        }
        set {
          _PrepaymentCalculating = value;
        }
    } protected bool? _PrepaymentCalculating =null;
