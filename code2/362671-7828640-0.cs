    public void CopyPropertiesFrom(BaseClass other)
    {
        if (other.GetClass() != GetClass())
        {
            throw new ArgumentException("...");
        }
    }
