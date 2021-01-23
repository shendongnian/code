    private int _MaxWidth;
    public int MaxWidth
    {
        get
        {
            return _MaxWidth;
        }
        set
        {
            _MaxWidth = value;
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(ImageUrl)) return;
        using (System.Drawing.Image MyImage =
            System.Drawing.Image.FromFile
            (HttpContext.Current.Server.MapPath(ImageUrl)))
        {
            int CurrentWidth = MyImage.Width;
            if (MaxWidth != 0 && CurrentWidth > MaxWidth)
            {
                CurrentWidth = MaxWidth;
            }
            Attributes.Add("width", CurrentWidth.ToString());
        }
    }
