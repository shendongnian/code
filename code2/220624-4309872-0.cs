public string GetFullPath(TreeViewItem node) 
{
  if (node == null)
    throw new ArgumentNullException();
  var result = Convert.ToString(node.Content);
  for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
    result = i.Header + "\\" + result;
  return result;
}
