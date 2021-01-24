c#
protected int Month
{
    get
    {
        if (ViewState["month"] == null)
        {
            ViewState["month"] = 3;
        }
        return (int)ViewState["month"];
    }
    set
    {
        // valid range for DateTime-Month is [1..12]
        if (value > 12) // check valid range
        {
            value = value % 12;
        }
        else if (value < 1)
        {
            value = 3;  // set default march
        }
        ViewState["month"] = value;
        lblMonth.Text = new DateTime(year: 1970, month: value, day: 1).ToString("MMMM") + " :";
    }
}
// ...
protected void dgvBudget_SelectedIndexChanged(object sender, EventArgs e)
    {
        Month = 3; // Reset to march
        selected = dgvBudget.SelectedIndex;
        txtGLType.Text = dgvBudget.Rows[selected].Cells[1].Text;
        txtYear.Text = dgvBudget.Rows[selected].Cells[2].Text;
    }
protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Month++;
    }
