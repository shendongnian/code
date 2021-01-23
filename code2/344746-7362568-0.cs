    private void PopulateSelectList(Control parentCtrl, List<DropDownList> selectList)
    {
        foreach (Control ctrl in parentCtrl.Controls)
        {
            if (ctrl is DropDownList)
            {
                selectList.Add(((DropDownList)ctrl);
                continue;
            }
            FindAllControls(ctrl, selectList);
        }
    }
