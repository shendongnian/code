    //Allows us to compare BasicItems as if Name is the key
    class NameComparer: IEqualityComparer<BasicItem>
    {
        public bool Equals(BasicItem first, BasicItem second)
        {
            return first.Name == second.Name;
        }
        public int GetHashCode(BasicItem value)
        {
            return value.Name.GetHashCode;
        }
    }
