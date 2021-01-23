    public DropDownComparer : EqualityComparer<DropDownListClass>
    {
        public override bool Equals(DropDownListClass i1, DropDownListClass i2)
        {
            bool rslt = (i1.Id == i2.Id) && (i1.Name == i2.Name);
        }
    
        public override int GetHashCode(DropDownListClass x)
        {
            return x.Id.GetHashCode() ^ x.Id.GetHashCode();
        }
    }
