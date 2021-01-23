    int? _result = null;
    public int Result {
        get {
            if ( _result == null )
                _result = A * B;
            return _result;
        }
    }
