    for (int i = 0; i < DTG_Mod.Items.Count; i++)
    {
     drv = (DataRowView)DTG_Mod.Items.GetItemAt(i);
     var item = DTG_Mod.Items[i];
     var CBM = DTG_Mod.Columns[0].GetCellContent(item) as CheckBox;
     if ((bool)CBM.IsChecked)
     { do something...
