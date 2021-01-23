    private void myComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (myComboBox.SelectedItem != null)
        {
            var x = myComboBox.SelectedItem;
            System.Type type = x.GetType();
            int id = (int)type.GetProperty("Id").GetValue(obj, null);
        }  
    }
