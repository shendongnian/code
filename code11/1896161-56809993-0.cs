    public override bool Equals(object obj)
    {
        return obj is A other
            && this.Prop == other.Prop
            && this.GetType() == other.GetType(); // otherwise, could be true for A-B pairs
    }
