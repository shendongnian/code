    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(ButtonPanelXEditor), typeof(UITypeEditor))]
    public List<CompactButton> CompactButtons
    {
        get { return _compactButtons; } // _compactButtons must of course be initialized.
    }
