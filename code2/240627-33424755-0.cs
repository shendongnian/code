    [DefaultValue("")]
    public override string Text
    {
        get { return base.Text; }
        set
        {
            if (this.DesignMode && (Environment.StackTrace.Contains("System.Windows.Forms.Design.ControlDesigner.InitializeNewComponent")))
                return;
            base.Text = value; 
            Invalidate();
        }
    }
