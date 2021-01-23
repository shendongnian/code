    public static bool operator ==(MyTest x, MyTest y) {
        if(x == null && y == null) return true;
        return x != null && y != null && x.me == y.me;
    }
    public static bool operator !=(MyTest x, MyTest y) {
        if (x == null && y == null) return false;
        return x == null || y == null || x.me != y.me;
    }
    public override bool Equals(object obj) {
        MyTest other = obj as MyTest;
        return other != null && other.me == me;
    }
    public override int GetHashCode() {
        return me == null ? 0 : me.GetHashCode();
    }
