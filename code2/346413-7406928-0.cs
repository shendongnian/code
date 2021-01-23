    string[] var4 = new string[] { 
        "Issue=" + DropDownListIssue.SelectedItem.ToString(),
        string.IsNullOrEmpty(DropDownListSubIssue.SelectedItem.ToString()) ? "SubIssue=" + DropDownListSubIssue.SelectedItem.ToString() : "",
        string.IsNullOrEmpty("Layout=" + DropDownListLayout.SelectedItem.ToString()) ? "Layout=" + DropDownListLayout.SelectedItem.ToString() : ""
    };
