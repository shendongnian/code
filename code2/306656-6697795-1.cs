    readonly Dictionary<string, HashSet<ToolStripButton>> mButtonGroups;
    ...
    ToolStripButton AddGroupedButton(string pText, string pGroupName) {
       var newButton = new ToolStripButton(pText);
       HashSet<ToolStripButton> buttonGroup;
       if (!mButtonGroups.TryGetValue(pGroupName, out buttonGroup)) {
          buttonGroup = new HashSet<ToolStripButton>();
          mButtonGroups.Add(pGroupName, buttonGroup);
       }
       newButton.Click += (s, e) => {
          foreach (var button in buttonGroup)
             button.Checked = button == newButton;
       };
       return newButton;
    }
