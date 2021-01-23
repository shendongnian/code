    private void Form1_Load(object sender, EventArgs e)
    {
        comboBoxAdminVisit.DataSource = be.Events;
        comboBoxAdminVisit.DisplayMember = "EventName";
    }
    private void comboBoxAdminVisit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxAdminVisit.SelectedItem != null)
        {
            Event selectedEvent = (Event)comboBoxAdminVisit.SelectedItem;
            var visitors = (from cc in be.Visitors
                            where cc.Attending.Events.Contains(x => x.EnventId = selectedEvent.Id)
                            select cc);
            comboBoxAdminName.DataSource = visitors;
            comboBoxAdminName.DisplayMember = "Name";
        }
    }
