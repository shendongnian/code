     List<PictureBox> pictureBoxList = new List<PictureBox>(10);
        int ID = 0;
        int position = 0;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            ID++;
            pictureBoxList.Add((PictureBox)Controls.Find("pictureBox" + ID, true)[0]);
            pictureBoxList[position].Location = new System.Drawing.Point(1, 90);
            pictureBoxList[position].Name = "pictureBoxEnemy";
            pictureBoxList[position].Size = new System.Drawing.Size(25, 25);
            pictureBoxList[position].BackgroundImage = Properties.Resources.Enemy;
            pictureBoxList[position].BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxList[position].BringToFront();
            position++;
        }
