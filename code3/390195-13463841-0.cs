    Form2_Load(object sender, EventArgs e)
    {
        if (Owner != null)
            Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                Owner.Location.Y + Owner.Height / 2 - Height / 2);
    }
