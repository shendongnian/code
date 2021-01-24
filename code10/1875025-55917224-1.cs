    public static void SelectComboBoxItem(this AutomationElement comboBox, string item)
    {
        var expandCollapsePattern = comboBox.GetPattern<ExpandCollapsePattern>(ExpandCollapsePatternIdentifiers.Pattern);
        expandCollapsePattern.Expand();
        expandCollapsePattern.Collapse();
        var listItem = comboBox.FindFirst(TreeScope.Subtree,
            new PropertyCondition(AutomationElement.NameProperty, item));
        var walker = TreeWalker.ControlViewWalker;
        var parent = walker.GetParent(listItem);
        while (parent != comboBox)
        {
            listItem = parent;
            parent = walker.GetParent(listItem);
        }
        var selectionItemPattern = listItem.GetPattern<SelectionItemPattern>(SelectionItemPatternIdentifiers.Pattern);
        selectionItemPattern.Select();
    }
