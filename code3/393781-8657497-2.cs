    public List<Note> noteList = new List<Note>(); 
    protected override void OnPaint(PaintEventArgs e)
    {
        int yPos = kOffset + staffIndex * kStaffSpacing;
        for (int bars = 0; bars < 5; bars++)
        {
            e.Graphics.DrawLine(Pens.Black, 0, yPos, kStaffInPixels, yPos);
            yPos += kBarSpacing;
        }
        foreach (var note in noteList)
        {
            note.Draw(e.Graphics);
        }
    }
