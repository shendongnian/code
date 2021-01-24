    private void Form1_Load(object sender, EventArgs e)
    {
        panel1.AllowDrop = true;
    }
    private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
    {    
        listView1.DoDragDrop(listView1.SelectedItems[0].Text , DragDropEffects.Copy);
    }
    private void panel1_DragDrop(object sender, DragEventArgs e)
    {
        panel1.BackgroundImage = Image.FromFile((string)e.Data.GetData(typeof(string)) + ".png");
    }
    private void panel1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
