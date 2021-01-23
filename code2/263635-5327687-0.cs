    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.tabControl1.SelectedIndex == 0)
        {
            this.decodeControl1.TriggerKey = HHP.DataCollection.Common.TriggerKeyEnum.TK_ONSCAN;
            this.imageControl1.TriggerKey = null;
        }
        else if (this.tabControl1.SelectedIndex == 1)
        {
            this.decodeControl1.TriggerKey = null;
            this.imageControl1.TriggerKey = TriggerKeyEnum.TK_ONSCAN;
        }
    }
