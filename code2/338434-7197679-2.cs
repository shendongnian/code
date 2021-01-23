    public override bool Equals(object o) {
    var other=o as Test;
    return other!=null && this.ID==other.ID;
    }
    
    public override int GetHashCode() {
    return ID.GetHashCode();
    }
