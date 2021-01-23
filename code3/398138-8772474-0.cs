    foreach ( RepeaterItem item1 in Repeater.Items )
    {
      if ( item.ItemType == ListItemType.Item)
      {
        TextBox txt =  (TextBox)item.FindControl(("MainContent_ParentRepeater_ChildRepeater_0_HB1_0")) as TextBox;
        // do something with "myTextBox.Text"
        break;
      }
    }
