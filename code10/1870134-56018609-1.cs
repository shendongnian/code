    for (int i = 0; i < DTG_Can.Items.Count; i++)
    {
     drv = (DataRowView)DTG_Can.Items.GetItemAt(i);
     var item = DTG_Can.Items[i];
     var CBM = DTG_Can.Columns[0].GetCellContent(item) as CheckBox;
     if (CBM.IsChecked == true && flagIns == 0) MessageBox.Show(i.ToString() + " - " + drv[2].ToString().ToUpper());
     else MessageBox.Show(i.ToString() + " - No Check");
