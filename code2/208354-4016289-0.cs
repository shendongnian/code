    private Parent _parent;
    public Parent parent { 
        get { return _parent; }
        set {
            if(_parent == value)
                 return;  //Prevents circular assignement
            if(null != _parent) {
                Parent temp = _parent;
                _parent = null;
                temp.removeChild(this);
            }
            if(null != value) {
                 _parent = value;
                 value.addChild(this);  
            }
        }
    }
