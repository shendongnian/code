c#
//a class level variable.
private int HoverIndex = -1;
private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
{
    var g = e.Graphics;
    var tp = tabControl1.TabPages[e.Index];
    var rt = e.Bounds;
    var rx = new Rectangle(rt.Right - 20, (rt.Y + (rt.Height - 12)) / 2 + 1, 12, 12);
    if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
    {
        rx.Offset(0, 2);
    }
    rt.Inflate(-rx.Width, 0);
    rt.Offset(-(rx.Width / 2), 0);
    using (Font f = new Font("Marlett", 8f))
    using (StringFormat sf = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center,
        Trimming = StringTrimming.EllipsisCharacter,
        FormatFlags = StringFormatFlags.NoWrap,
    })
    {
        g.DrawString(tp.Text, tp.Font ?? Font, Brushes.Black, rt, sf);
        g.DrawString("r", f, HoverIndex == e.Index ? Brushes.Black : Brushes.LightGray, rx, sf);
    }
    tp.Tag = rx;
}
Note that, now the `Tag` property of each `TabPage` control holds a rectangle for the `x` button.
In the `MouseMove` event iterate through the `TabPages`, cast the `x` rectangle from the `Tag` property, check if the `x` rectangle contains the current `e.Location`, and call `Invalidate();` method of the `TabControl` to update the drawing:
c#
private void tabControl1_MouseMove(object sender, MouseEventArgs e)
{
    for (int i = 0; i < tabControl1.TabCount; i++)
    {
        var rx =(Rectangle)tabControl1.TabPages[i].Tag;
        if (rx.Contains(e.Location))
        {
            //To avoid the redundant calls. 
            if (HoverIndex != i)
            {
                HoverIndex = i;
                tabControl1.Invalidate();
            }
            return;
        }
    }
    //To avoid the redundant calls.
    if (HoverIndex != -1)
    {
        HoverIndex = -1;
        tabControl1.Invalidate();
    }
}
In the `MouseLeave` event invalidate if necessary:
c#
private void tabControl1_MouseLeave(object sender, EventArgs e)
{
    if (HoverIndex != -1)
    {
        HoverIndex = -1;
        tabControl1.Invalidate();
    }
}
And to close/dispose a page, handle the `MouseUp` event:
c#
private void tabControl1_MouseUp(object sender, MouseEventArgs e)
{
    for(int i = 0; i < tabControl1.TabCount; i++)
    {
        var rx = (Rectangle)tabControl1.TabPages[i].Tag;
        if (rx.Contains(e.Location))
        {
            tabControl1.TabPages[i].Dispose();
            return;
        }                                    
    }
}
Good luck.
