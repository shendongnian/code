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
Hope it's clear now.
Good luck
