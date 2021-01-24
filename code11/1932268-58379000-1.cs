    var lstChckBox = new List<CheckBox>( );
    var InitialYPosition = KalenderLbl.Location.Y + KalenderLbl.Height + 5;
    for (int i = 0; i < appointments.TotalCount; i++)
    {
        box = new CheckBox( ) {
            Tag = i,
            Text = appointments.Items[i].Subject,
            AutoSize = true,
            Location = new Point( KalenderLbl.Location.X, InitialYPosition + ( i * 25 ) )
        };
        lstChckBox.Add( box );
        box.CheckedChanged += new EventHandler( chck_CheckedChanged );
        Controls.Add( box );
    }
