    int carpick, qty, total, i = 0;
    protected void Button1_Click1(object sender, EventArgs e)
    {
        carpick = Convert.ToInt32(CarpickDD.SelectedItem.Value);
        qty = Convert.ToInt32(QTYDD.SelectedItem.Value);
        total = ((carpick * qty) + (750 * qty));
        switch (i++)
        {
            case 0:
                Label1.Text = CarpickDD.SelectedItem.Text;
                Label2.Text = CarpickDD.SelectedItem.Value;
                Label3.Text = QTYDD.SelectedItem.Value;
                Label4.Text = Convert.ToString(total);
                break;
            case 1:
                Label5.Text = CarpickDD.SelectedItem.Text;
                Label6.Text = CarpickDD.SelectedItem.Value;
                Label7.Text = QTYDD.SelectedItem.Value;
                Label8.Text = Convert.ToString(total);
                break;
            case 2:
                ..... etc ....
        }
    }
