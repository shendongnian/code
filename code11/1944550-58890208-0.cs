        List<PictureBox> pictureBoxList = new List<PictureBox>(10);
        int ID = 0;
        private void buttonAddEnemy_Click(object sender, EventArgs e)
        {
            Control[] pictureControls = Controls.Find("pictureBox", true);
            if (pictureControls != null && pictureControls.Length > 0)
            {
                pictureBoxList.Add((PictureBox)pictureControls[0]);
                pictureBoxList[ID].Location = new System.Drawing.Point(1, 90);
                pictureBoxList[ID].Name = "pictureBoxEnemy";
                pictureBoxList[ID].Size = new System.Drawing.Size(25, 25);
                pictureBoxList[ID].BackgroundImage = Properties.Resources.Enemy;
                pictureBoxList[ID].BackgroundImageLayout = ImageLayout.Zoom;
                pictureBoxList[ID].BringToFront();
            }
        }    
