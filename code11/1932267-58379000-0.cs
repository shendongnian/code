    var lstChckBox = new List<CheckBox>( );
    for (int i = 0; i < appointments.TotalCount; i++)
    {
        box = new CheckBox( );
        box.Tag = i;
        box.Text = appointments.Items[i].Subject;
        box.AutoSize = true;
        box.Location = new Point( KalenderLbl.Location.X, KalenderLbl.Location.Y + KalenderLbl.Height + 5 + ( i * 25 ) );
        lstChckBox.Add( box );
        box.CheckedChanged += new EventHandler( chck_CheckedChanged );
        Controls.Add( box );
    }
    void chck_CheckedChanged( object sender, EventArgs e )
    {
        foreach (CheckBox item in lstChckBox)
        {
            if (item.Checked == true)
            {
                Hide( );
            }
        }
    }
