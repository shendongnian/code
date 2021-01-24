    private void panel1_DragDrop(object sender, DragEventArgs e)
    {
        string pic = (string)e.Data.GetData(typeof(string)) + ".png"
        Image img = Image.FromFile(pic);
        panel1.BackgroundImage = img;
    }
