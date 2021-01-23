    string[] possibleNulllVar4 = new string[] { 
        string.IsNullOrEmpty(DropDownListIssue.SelectedItem.ToString()) ? "Issue=" + DropDownListIssue.SelectedItem.ToString() : null,
        string.IsNullOrEmpty(DropDownListSubIssue.SelectedItem.ToString()) ? "SubIssue=" + DropDownListSubIssue.SelectedItem.ToString() : null,
        string.IsNullOrEmpty(DropDownListLayout.SelectedItem.ToString()) ? "Layout=" + DropDownListLayout.SelectedItem.ToString() : null
    };
