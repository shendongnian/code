    public override bool Equals(object obj)
    {
        bool equals = false;
        if (null != obj)
        {
            RatingsLipper temp = obj as RatingsLipper;
            if (null != temp)
            {
                equals = (this.ShareClassId == temp.ShareClassId 
                    && this.TimePeriod.Equals(temp.TimePeriod) 
                    && this.Id.Equals(temp.Id)
                    && this.RatingDate.Equals(temp.RatingDate));
            }
        }
        return equals;
    }
    public override int GetHashCode()
    {
        int hash = 1122; // no idea of the significance of this number!
        hash += (this.ShareClassId.GetHashCode());
        hash += (this.TimePeriod.GetHashCode());
        hash += (this.Id.GetHashCode());
        hash += (this.RatingDate.GetHashCode());
        return hash;
    }
