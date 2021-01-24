    public double Acropromazine()
    {
        if (mType == "Dog")
        {
            return (mWeight / 2.205) * (0.03 / 10);
        }
        else if (mType == "Cat")
        {
            return (mWeight / 2.205) * (0.002 / 10);
        }
        else throw new NotSupportedException("only cats and dogs support Acropromazine");
    }
