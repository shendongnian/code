c#
private void treeView1_MouseMove(object sender, MouseEventArgs e)
{
    var node = treeView1.GetNodeAt(e.Location);
    if (node != null)
    {
        var parent = node.Parent;
        while (parent != null)
        {
            if (parent.Text == "tarNode")
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
