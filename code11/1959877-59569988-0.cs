    private async void button1_Click(object sender, EventArgs e)
    {
        await AddExplodablePictureBox();
    }
    async Task AddExplodablePictureBox()
    {
        var p = new PictureBox();
        p.BackColor = Color.Red;
        //Set the Image and other properties
        this.Controls.Add(p);
        await Task.Delay(3000);
        p.Dispose();
    }
