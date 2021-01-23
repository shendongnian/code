     public string RadDropDownSelectValue(RadDropDownList radDropDownList)
        {
            string str = "";
            foreach (RadListDataItem item in radDropDownList.SelectedItems)
            {
                DataRowView dv = (DataRowView)item.Value;
                str = dv.Row[0].ToString();
            }
            return str;
        }
