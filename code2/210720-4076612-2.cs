    public object this[string key] {
        get {
            if (key == "Config1") return this.Config1;
            else return propBag[key];
        }
        set {
            if (key == "Config1") this.Config1 = value;
            else propBag[key] = value;
        }
    }
