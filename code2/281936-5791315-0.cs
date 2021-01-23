    public override bool Equals(object other)
    {
        return Equals(other as Message);
    }
    public bool Equals(Message other)
    {
      if (other == null) { return false; }
      return this.Id == other.Id;
    }
    public override int GetHashCode()
    {
      // If the ID is unique, then it satisfied the purpose of 'GetHashCode'
      return this.Id;
    }
