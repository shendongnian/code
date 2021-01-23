    public override bool Equals(object obj)
      {
        Class1 other = obj as Class1;
        if (other == null || other.GetHashCode() != this.GetHashCode())
            return false;
        // the hash codes are the same so you have to do a full object compare.
      }
