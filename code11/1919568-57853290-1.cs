    private int Id { get; set; }
    public string Code { get; set; }
    
    private string _name;
    public string Name
    {
        get {
            return (this.Id == null) ? null : this.Id+ "/" + this.Code;
        }
        set {
            if (this._name != value)
                this._name= value;
        }
    }
    public bool IsValid() => return this.Id != null;
