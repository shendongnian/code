    ((ListBox)MyCheckBoxList).DataSource = dt;
    ((ListBox)MyCheckBoxList).DisplayMember = "name";
                        ...
    for (int i = 0; i < folloving.Items.Count; i++ )
    {
        DataRowView row = (DataRowView)MyCheckBoxList.Items[i];
        bool isChecked = Convert.ToBoolean(row["checked"]);
        MyCheckBoxList.SetItemChecked(i, isChecked);
    }
