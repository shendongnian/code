    private bool DepartmentNodeExists(string name) {
        if (uxTreeView.Nodes[0].ContainsKey(name)) {
            return true;
        }
        else {
            return false;
        }
    }
