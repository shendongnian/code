    public override bool Equals(object obj)
    {
    T other = obj as T;
    if (other == null)
        return false;
 
    // handle the case of comparing two NEW objects
    bool otherIsTransient = Equals(other.Id, Guid.Empty);
    bool thisIsTransient = Equals(Id, Guid.Empty);
    if (otherIsTransient && thisIsTransient)
        return ReferenceEquals(other, this);
 
    return other.Id.ToUpper().Equals(Id.ToUpper());
    }
