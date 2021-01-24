protected override void OnCreateControl()
{
    base.OnCreateControl();
    this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15)); //play with these values till you are happy
}
with this:
protected override void OnResize(EventArgs e)
{
    base.OnResize(e);
    this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15)); //play with these values till you are happy
}
Good luck.
