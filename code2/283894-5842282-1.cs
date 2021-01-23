    protected void Submit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            TextBox txtMarksScored = (TextBox)gvr.FindControl("txtMarksScored");
            // Hope you understand what to do next?
            // txtMarksScored.Text
        }
    }
