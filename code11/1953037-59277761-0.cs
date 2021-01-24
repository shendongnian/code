    private void Form1_Load(object sender, EventArgs e)
    {
        PictureBox pictureBox = new PictureBox();
        this.tableLayoutPanel1.Controls.Add(pictureBox, 1,1);
        // Set background image
        pictureBox.Image = Properties.Resources.TestImage;
        // Set background color
        //pictureBox.BackColor = Color.Red;
    }
