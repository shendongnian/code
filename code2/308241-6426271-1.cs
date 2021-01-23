    public string GetValue(params object[] controls)
    {
        foreach (var item in controls)
        {
            if (item != null)
            {
                if (item is TextBox)
                    return (item as TextBox).Text;
                if (item is CheckBox)
                    return (item as CheckBox).Checked.ToString();
                if (item is DropDownList)
                    return (item as DropDownList).SelectedValue.ToString();
            }
        }
        return string.Empty;
    }
