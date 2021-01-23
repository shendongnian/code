    public override int GetHashCode()
    {
        if (this.Zipcode == "11111" || this.Zipcode == "22222" || this.Zipcode== "33333")
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ MiddleName.GetHashCode();
        }
        else
        {
            return FirstName.GetHashCode();
        }
    }
