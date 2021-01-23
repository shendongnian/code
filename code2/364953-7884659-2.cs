    public void Remove_Click(object sender, EventArgs e)
    {
        if (lastLabel != null)
        {
            flowLayoutPanel1.Controls.Remove(lastLabel);
            lastLabel = null;
        }
    }
