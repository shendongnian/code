    private Color _WhiteBrush = Color.White;
    public Color WhiteBrush
    {
      get
      {
         return _WhiteBrush;
      }
      set
      {
        _WhiteBrush = value;
        this.Invalidate();
      }
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
      using (SolidBrush sb = new SolidBrush(this.WhiteBrush))
      {
        e.Graphics.FillRectangle(sb, this.ClientRectangle);
      }
    }
