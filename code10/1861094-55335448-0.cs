public partial class BrokenControl : TreeView
{
   ...
   public void Go(object sender, EventArgs e)
   {
       Nodes.Add("Root");
       TreeNode savedNode = RecursiveEdit(Nodes[0]);
       
       //This fixes it.
       Nodes.Clear();
       Nodes.Add(savedNode);
       Update();
   }
   ...
}
