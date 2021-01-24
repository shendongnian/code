    public override bool Equals(object obj)
    {
        return obj is A other
            && this.Prop == other.Prop
            && this.GetType() == other.GetType(); // not needed if A is sealed
    }
