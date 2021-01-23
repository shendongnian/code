protected void TreeView1_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
{
  e.Node.Text = "&lt;input type='radio' /&gt;" + e.Node.Text;
}
protected override void Render(HtmlTextWriter writer)
{
    base.Render(writer);
    TreeView1.RenderControl(writer);
}
