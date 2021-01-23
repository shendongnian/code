    [DefaultValue(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Gets or sets whether the \"Remove\" button is visible.")]
    public bool ShowRemoveButton
    {
        get
        {
            return _showRemoveButton;
        }
        set
        {
            _showRemoveButton = value;
            this.removeButton.Visible = value;
        }
    }
    private bool _showRemoveButton = true;
