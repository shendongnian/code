C#
public static class Extensions
{
    public static String GetPath(this TreeNode tn)
    {
        String path = tn.Text;
        if (tn.Parent != null)
        {
            //  If we have a parent, get his path and stick it in front of our text.
            //  If tn.Parent was null, tn is the root and we'll just return tn.Text.
            path = GetPath(tn.Parent) + "\\" + path;
        }
        return path;
    }
}
Usage:
C#
_NewPath = pathTxt.Text + "\\" + treeView1.SelectedNode.GetPath().
