    protected void gridView_DataBound(object sender, EventArgs e)
    {
        const int countriesColumnIndex = 4;
        if (someCondition == true)
        {
            // Hide the Countries column
            this.gridView.Columns[countriesColumnIndex].Visible = false;
        }
    }
