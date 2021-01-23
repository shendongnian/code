    private Model.Sesion _Sesion = Code.Session.Session.Sesion;
    public Model.Sesion Sesion
    {
        get
        {
            return _Sesion;
        }
        set
        {
            if (_Sesion == value)
            {
                return;
            }
            var oldValue = _Sesion;
            _Sesion = value;
            // Update bindings, no broadcast
            RaisePropertyChanged(SesionPropertyName);
        }
    }
