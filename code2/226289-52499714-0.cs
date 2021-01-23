    public override Size GetPreferredSize(Size proposedSize)
    {
        Size s = base.GetPreferredSize(proposedSize);
        if (AutoSize)
        {
            s.Width += 15;
        }
        return s;
    }
