                var u = new StringBuilder();
                u.Append(DropDownList1.SelectedItem.Value);
                u.Append(DropDownList3.SelectedItem.Value.PadLeft(3, '0'));
                u.Append(DropDownList2.SelectedItem.Value);
                u.Append(TextBox2.Text.ToString());
                u.Append(TextBox3.Text.ToString());
