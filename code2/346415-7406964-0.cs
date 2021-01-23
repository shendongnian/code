    List<string> list = new List<string>();
    var str = DropDownListIssue.SelectedItem.ToString();
    if (!string.IsNullOrEmpty(str))
        list.Add("Issue=" + str);
    str = DropDownListSubIssue.SelectedItem.ToString();
    if (!string.IsNullOrEmpty(str))
        list.Add("SubIssue=" + str);
    str = DropDownListLayout.SelectedItem.ToString();
    if (!string.IsNullOrEmpty(str))
        list.Add("Layout=" + str);
    string[] var4 = list.ToArray();
