    pictureBoxList.Add((PictureBox)Controls.Find("pictureBox" + ID, true)[0]);
    pictureBoxList[ID].Location = new System.Drawing.Point(1, 90);
    pictureBoxList[ID].Name = "pictureBoxEnemy";
    pictureBoxList[ID].Size = new System.Drawing.Size(25, 25);
    pictureBoxList[ID].BackgroundImage = Properties.Resources.Enemy;
    pictureBoxList[ID].BackgroundImageLayout = ImageLayout.Zoom;
    pictureBoxList[ID].BringToFront();
    ID++;
