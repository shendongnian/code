c#
private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
{
    if (e.Action == TreeViewAction.Unknown) { return; }
    foreach (TreeNode tn in GetNodes(e.Node))
        tn.Checked = e.Node.Checked;
}
private static IEnumerable<TreeNode> GetNodes(TreeNode parentNode)
{
    foreach (TreeNode tn in parentNode.Nodes)
    {
        yield return tn;
        foreach (TreeNode child in GetNodes(tn))
        {
            yield return child;
        }
    }
}
This way, you can use this iterator to do other things to your nodes not only to check/uncheck them.
**Edit**
> You can see this strange behaviour in the seconds 7, 10, 15.
I got your point now.
That behavior occurs when you mouse click too fast on a node so you are actually doing mouse click, mouse double click sequence. The tree view control by default does not toggle the check state of the nodes through the mouse double click unless you tell it to do so. How? Already answered by [PhilP](https://stackoverflow.com/users/2262826/philp) in [this](https://stackoverflow.com/questions/6130297/c-how-to-avoid-treenode-check-from-happening-on-a-double-click-event/6130543) question.
+ Create a new class that inherits the tree view control and override the **WndProc** event as follow:
class TreeViewEx : TreeView
{
    public TreeViewEx()
    { }
    #region This extra to reduce the flickering
    private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
    private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
    private const int TVS_EX_DOUBLEBUFFER = 0x4;
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    protected override void OnHandleCreated(EventArgs e)
    {
        SendMessage(Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
        base.OnHandleCreated(e);
    }
    #endregion
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x203 && CheckBoxes)
        {
            int x = m.LParam.ToInt32() & 0xffff;
            int y = (m.LParam.ToInt32() >> 16) & 0xffff;
            TreeViewHitTestInfo hitTestInfo = HitTest(x, y);
            if (hitTestInfo.Node != null && hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
            {
                OnBeforeCheck(new TreeViewCancelEventArgs(hitTestInfo.Node, false, TreeViewAction.ByMouse));
                hitTestInfo.Node.Checked = !hitTestInfo.Node.Checked;
                OnAfterCheck(new TreeViewEventArgs(hitTestInfo.Node, TreeViewAction.ByMouse));
                m.Result = IntPtr.Zero;
                return;
            }
        }
        base.WndProc(ref m);
    }
}
+ In the designer of the form which contains your tree view, change the type of the tree view to the extended one that we just created.
+ Use the same code to toggle the check state.
+ Rebuild your project.
That's it all.
Here is a quick demo. I'm mouse clicking and double clicking like crazy. However, it works as it should. Hopefully.
[![Tree View Demo][1]][1]
Good luck
  [1]: https://i.stack.imgur.com/Xbv70.gif
