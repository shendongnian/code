    public virtual Color BackColor
    {
        set
        {
            if ((!value.Equals(Color.Empty) && !this.GetStyle(ControlStyles.SupportsTransparentBackColor)) && (value.A < 0xff))
            {
                throw new ArgumentException(SR.GetString("TransparentBackColorNotAllowed"));
            }
            Color backColor = this.BackColor;
            if (!value.IsEmpty || this.Properties.ContainsObject(PropBackColor))
            {
                this.Properties.SetColor(PropBackColor, value);
            }
            if (!backColor.Equals(this.BackColor))
            {
                this.OnBackColorChanged(EventArgs.Empty);
            }
        }
    }
