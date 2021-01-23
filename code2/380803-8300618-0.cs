    private void AddListToTree<T>(ComponentArt.Web.UI.TreeView treeView,
                                  IList<T> list)
    {
        var orderedList = list.OrderBy(t => t);
    }
