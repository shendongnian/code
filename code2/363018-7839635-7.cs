    if ((test.ID == "SumbitSearch") && (DropDownListFrom.Text != "") && (DropDownListTo.Text != "") && (SearchField.Text != ""))
    {
        string from = string.Empty;
        string to = string.Empty;
        switch (DropDownListFrom.SelectedIndex)
        {
            case 0:
                from = DropDownListFrom.Items[0].Value;
                break;
            /* other cases */
        }
        switch (DropDownListTo.SelectedIndex)
        {
            case 0:
                to = DropDownListTo.Items[0].Value;
                break;
            /* other cases */
        }
        /* snip */
    }
