    private void staff1_MouseClick(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
            staff1.noteList.Add(new SimpleNote(new Point(e.X, e.Y)));
        if(e.Button == MouseButtons.Right)
            staff1.noteList.Add(new DifficultNote(new Point(e.X, e.Y)));
        if(e.Button == MouseButtons.Middle)
                staff1.noteList.Add(new PictureNote(new Bitmap("c:\\note.png"), new Point(e.X, e.Y)));
           staff1.Invalidate();
    }
