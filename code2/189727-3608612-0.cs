    switch (ItemType)
    {
      case ListItemType.Item:
        if (InfoType == "CheckBox")
        {
          string value = bound_value_obj.ToString();
          bool ischecked = false;
          if (value.ToLower() == "true")
            ischecked = true;
          CustomCheckBox cbox = (CustomCheckBox)sender;
          cbox.CheckedChanged -= new EventHandler(checkbox_CheckedChanged);
          cbox.Checked = ischecked;
          cbox.RowID = rowid;
          cbox.FieldName = FieldName;
          cbox.CheckedChanged += new EventHandler(checkbox_CheckedChanged);
        }
        else
        {
          Label field_ltrl = (Label)sender;
          field_ltrl.Text = bound_value_obj.ToString();
        }
    
        break;
