    /// <summary>
    /// inspired by this forum entry: http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/10f75954-6d14-4926-a02d-98649653b9c8/
    /// Watermark TextBox in winform
    /// </summary>
    public class WatermarkTextBox : TextBox
    {
      private string watermarkText;
      private Color watermarkColor;
      private Color foreColor;
      private bool isTextBoxEmpty;
    
      public WatermarkTextBox()
      {
        this.WatermarkText = "Watermark Text...";
        this.WatermarkColor = Color.FromKnownColor(KnownColor.Silver);
        this.Enter += onEnter;
        this.Leave += onLeave;
      }
      
      [Browsable(true)]
      public new Color ForeColor
      {
        get { return this.foreColor; }
        set
        {
          if (value == this.foreColor)
          {
            return;
          }
          this.foreColor = value;
          if (!this.isTextBoxEmpty)
          {
            base.ForeColor = value;
          }
        }
      }
      
      [Browsable(true)]
      public Color WatermarkColor
      {
        get { return this.watermarkColor; }
        set
        {
          if (value == this.watermarkColor)
          {
            return;
          }
          this.watermarkColor = value;
          if (this.isTextBoxEmpty)
          {
            base.ForeColor = this.watermarkColor;
          }
        }
      }
      
      [Browsable(true)]
      public string WatermarkText
      {
        get { return this.watermarkText; }
        set
        {
          if (value == this.watermarkText)
          {
            return;
          }
          this.watermarkText = value;
          if (base.Text.Length == 0)
          {
            this.isTextBoxEmpty = true;
            base.Text = this.watermarkText;
            base.ForeColor = this.watermarkColor;
          }
          this.Invalidate();
        }
      }
      
      public override string Text
      {
        get { return this.isTextBoxEmpty ? string.Empty : base.Text; }
        set
        {
          if (string.IsNullOrEmpty(value))
          {
            this.isTextBoxEmpty = true;
            base.ForeColor = this.watermarkColor;
            base.Text = this.watermarkText;
          }
          else
          {
            this.isTextBoxEmpty = false;
            base.ForeColor = this.foreColor;
            base.Text = value;
          }
        }
      }
      
      private void onEnter(object sender, EventArgs e)
      {
        if (this.isTextBoxEmpty)
        {
          this.isTextBoxEmpty = false;
          base.ForeColor = this.foreColor;
          base.Text = string.Empty;
        }
      }
      
      private void onLeave(object sender, EventArgs e)
      {
        if (string.IsNullOrEmpty(base.Text))
        {
          this.isTextBoxEmpty = true;
          base.ForeColor = this.watermarkColor;
          base.Text = this.watermarkText;
        }
        else
        {
          this.isTextBoxEmpty = false;
        }
      }
    }
