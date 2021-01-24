    private List<Notes> _notesCollection = new List<Notes>();
    private void btnAddNote_Click(object sender, EventArgs e)
    {
        var note = new Notes(txtNoteWriter.Text);
        _notesCollection.Add(note);
        txtNoteReader.Text = string.Join(Environment.NewLine, _notesCollection.OrderByDescending(x => x.TimeStamp).Select(x => x.ToString()));
    }
