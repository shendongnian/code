    public void SetStyle(Styles styles)
    {
        this.styles |= styles;
    }
    public void UnsetStyle(Styles styles)
    {
        this.styles &= ~styles;
    }
