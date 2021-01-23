    int x = 10;
    for (int i = 0; i < hardrive.GetHardDriveName.Count; i++)
        {
            
            int y = 10;
            lblHDDName[i] = new Label();
            lblHDDName[i].Location = new System.Drawing.Point(x, y);
            lblHDDName[i].Text = "Test";
            groupBoxHDD.Controls.Add(lblHDDName[i]);
            y += 30;
        }
