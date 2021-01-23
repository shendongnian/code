     public override int GetHashCode()
     {
        return (this.symbol == null ? 0 : this.symbol.GetHashCode())
           ^ (this.extension == null ? 0 : this.extension.GetHashCode());
     }
     public override bool Equals(object obj)
     {
        if (Object.ReferenceEquals(this, obj))
          return true;
        Quotes other = obj as Quotes;
        if (Object.ReferenceEquals(other, null))
          return false;
    
        return String.Equals(obj.symbol, this.symbol)
            && String.Equals(obj.extension, this.extension);
     }
