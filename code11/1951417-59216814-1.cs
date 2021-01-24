    private void PlanningDayPlans_Load(object sender, EventArgs e)
    {
        DataGridViewRow r = new DataGridViewRow();
        this.DataGridView1.Rows.Add(r);
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        this.DataGridView1.Rows(0).Cells(0).Value = My.Resources.todo2;
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        this.DataGridView1.Rows(0).Cells(0).Value = My.Resources.cross;
    }
