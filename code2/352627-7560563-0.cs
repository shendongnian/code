    public string GetItemValue()
    {
        for (int i = 0; i < listView1.Items.Count; i++)
        {
            if (listView1.Items[i].Checked == true)
            {
                // Here you are leaving the GetItemValue method
                // and the loop stops
                return listView1.Items[i].Text;
            }
        }
        // if we get that far it means that none of the items of
        // the select list was actually checked => we are better of
        // reporting this to the caller of the method
        throw new Exception("Please select a value");
    }
