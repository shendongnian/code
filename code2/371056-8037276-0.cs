    public new bool Enabled {
        get { return _Enabled; }
        set {
            _Enabled = value;
            textBox1.Enabled = value;
            base.Enabled = value;
        }
    }
