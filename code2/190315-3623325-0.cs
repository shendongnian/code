    int x = ((((DropDownList1.SelectedIndex+1)*(DropDownList1.SelectedIndex+1))-(DropDownList1.SelectedIndex+1))/2)-1;
        Label1.Text = x+"";
        for (int i = 0; i < x; i++)
        {
            CheckBox cb = new CheckBox();
            cb.Text = String.Format("PrefixName{0}" , Convert.ToString(i+1));
            PlaceHolder1.Controls.Add(cb);
            PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
        }
