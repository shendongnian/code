    private void AddListToTree(ComponentArt.Web.UI.TreeView treeView,
                               IList list)
    {
        var orderedList = list.Cast<SomeType>().OrderBy(x => x);
    }
