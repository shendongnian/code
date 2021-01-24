    int sum = 0;
    if (DateTime.Today == validDate)
    {
        for (int i = 0; i < SalesGridView.Rows.Count; ++i)
        {
            sum += Convert.ToInt32(SalesGridView.Rows[i].Cells[3].Value);
        }
        label1.Text = sum.ToString();
    }
