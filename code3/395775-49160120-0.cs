    /// <summary>
    /// Color used when the grid is disabled
    /// </summary>
    [Category("Appearance"), DefaultValue(typeof(Color), "Blank"), Description("Color to use when the control is disabled (should be transparent)")]
    public Color DisableColor { get; set; }
    
    /// <summary>
    /// Color used when the grid is disabled
    /// </summary>
    [Category("Appearance"), DefaultValue(50), Description("Alpha channel value for disabled color (0-255)")]
    public int DisableColorAlpha { get; set; }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    
        if (this.Enabled == false && DisableColor != null)
        {
            // paint a transparent box -- simulate disable
            using (Brush b = new SolidBrush(Color.FromArgb(DisableColorAlpha, DisableColor)))
            {
                e.Graphics.FillRectangle(b, e.ClipRectangle);
            }
        }
    }
