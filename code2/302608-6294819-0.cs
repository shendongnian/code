    public override string ToString()
    {
      return Number.FormatInt32(this, (string) null, NumberFormatInfo.CurrentInfo);
    }
    public string ToString(string format)
    {
      return Number.FormatInt32(this, format, NumberFormatInfo.CurrentInfo);
    }
    public string ToString(IFormatProvider provider)
    {
      return Number.FormatInt32(this, (string) null, NumberFormatInfo.GetInstance(provider));
    }
    public string ToString(string format, IFormatProvider provider)
    {
      return Number.FormatInt32(this, format, NumberFormatInfo.GetInstance(provider));
    }
