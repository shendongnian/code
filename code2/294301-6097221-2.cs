    private bool DepartmentNodeExists(string name) {
        foreach (TreeNode node in uxTreeView.Nodes[0].Nodes) {
            if (node.Name.ToLower() == name.ToLower()) {
                return true;
            }
        }
        return false;
    }
