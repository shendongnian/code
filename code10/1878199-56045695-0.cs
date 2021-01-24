    private async void btnTarget_Click(object sender, EventArgs e)
    {
        using (DataBaseDataContext db = new DataBaseDataContext())
        {
            targtGirdView.DataSource = await Task.Run(() =>
            {
                return heavyLinqToSQLQuery.ToList();
            });
        }
    }
