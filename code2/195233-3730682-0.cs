    public bool Frozen {
        get {
            Contract.Ensures(Contract.Result<bool>() == this._frozen);
            return _frozen;
        }
    }
