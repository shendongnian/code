    public override int GetHashCode()
    {
         return myLongName.GetHashCode() + myShortName.GetHashCode();
    } 
    public override bool Equals(object obj)
    {
         return GetHashCode() == obj.GetHashCode();
    } 
