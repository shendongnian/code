motherPictureBox.Controls.Add(newPictureBox);
So now my Code looks like this:
PictureBox newPictureBox = new PictureBox();
newPictureBox.Location = new Point(x:30,y:30);
newPictureBox.BackColor = Color.Red;
newPictureBox.Visible = true;
newPictureBox.Height = 200;
newPictureBox.Width = 200;
motherPictureBox.Controls.Add(newPictureBox);
Didn't need to bring it forward, I just forgot to add it...
