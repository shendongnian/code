     //setting the selected item in the second list
     if (selectedItem != null)
      listBox2.SelectedItem = (
        from item in listBox2.Items.Cast<DataRowView>()
        where item[listBox2.ValueMember].ToString() == ((DataRowView)selectedItem)[listBox1.ValueMember].ToString()
        select item).FirstOrDefault();
