    public bool Modified { get; set; }
    private bool enabled;
    public bool Enabled {
        get { return this.enabled; }
        set {
            if(this.enabled != value) {
                this.enabled = value;
                this.Modified = true;
            }
        }
    }
            
