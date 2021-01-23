    public new void Show(IWin32Window owner)
    {
        base.Show(owner);
        if (Owner != null)
            Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                Owner.Location.Y + Owner.Height / 2 - Height / 2);
    }
