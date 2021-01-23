     public override int GetHashCode()
     {
        return (this.symbol == null ? 0 : this.symbol.GetHashCode())
           ^ (this.extension == null ? 0 : this.extension.GetHashCode());
     }
     public override bool Equals(object obj)
     {
        Quotes other = obj as Quotes;
        if (Object.ReferenceEquals(other, obj))
          return false;
    
        return String.Equals(obj.symbol, this.symbol)
            && String.Equals(obj.extension, this.extension);
     }
