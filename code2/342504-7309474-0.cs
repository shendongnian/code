    public override int GetHashCode() {
      unchecked {
        int result=a.GetHashCode();
        result=(result*397)^b.GetHashCode();
        result=(result*397)^c.GetHashCode();
        result=(result*397)^d.GetHashCode();
        result=(result*397)^e.GetHashCode();
        result=(result*397)^f.GetHashCode();
        return result;
      }
    }
