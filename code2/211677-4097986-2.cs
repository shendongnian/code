    public string Name {
        get {
            return (name == null) ? "": name;
        }
        set {
            name = value;
            if (owner != null) {
                owner.UpdateSubItems(-1);
            }
        }
    }
