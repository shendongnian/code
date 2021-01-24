c#
private void treeView1_MouseMove(object sender, MouseEventArgs e)
{
    var node = treeView1.GetNodeAt(e.Location);
    if (node != null)
    {
        var parent = node.Parent;
        while (parent != null)
        {
            if (parent.Text == "someTxt")
            {
                if (Cursor != Cursors.Hand)
                            Cursor = Cursors.Hand;
                        return;
            }
            parent = parent.Parent;
        }
        Cursor = Cursors.Default;
    }
}
Also handle the `MouseLeave` event to check if there's a need to _Default_ the `Cursor`.
c#
private void treeView1_MouseLeave(object sender, EventArgs e)
{
    if (Cursor != Cursors.Default)
        Cursor = Cursors.Default;
}
Or if you prefer the Lambda way:
c#
//In the constructor:
treeView1.MouseMove += (s, e) =>
{
    var node = treeView1.GetNodeAt(e.Location);
    if (node != null)
    {
        var parent = node.Parent;
        while (parent != null)
        {
            if (parent.Text == "someTxt")
            {
                if (Cursor != Cursors.Hand)
                    Cursor = Cursors.Hand;
                return;
            }
            parent = parent.Parent;
        }
        Cursor = Cursors.Default;
    }
};
treeView1.MouseLeave += (s, e) =>
{
    if (Cursor != Cursors.Default)
        Cursor = Cursors.Default;
};
