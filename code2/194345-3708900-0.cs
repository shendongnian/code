    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [SRDescription("ControlDisplayRectangleDescr")]
    public virtual Rectangle DisplayRectangle
    {
        get
        {
            return new Rectangle(0x0, 0x0, this.clientWidth, this.clientHeight);
        }
    }
