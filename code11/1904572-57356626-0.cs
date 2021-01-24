    private void button1_Click(object sender, EventArgs e)
    {
        Eintrag.Anfangszeit.Add(new DateTimePicker());
        for (int i = 0; i < Eintrag.Anfangszeit.Count; i++) {
            Eintrag.Anfangszeit[i].Location = new System.Drawing.Point(30, 50 + 50 * i);
            Eintrag.Anfangszeit[i].Size = new System.Drawing.Size(200, 20);
            Eintrag.Anfangszeit[i].Visible = true;
            this.Controls.Add(Eintrag.Anfangszeit[i]);
            Eintrag.Anfangszeit[i].Show();            
        }
    }
