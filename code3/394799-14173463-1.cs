    private TextBox _form1ErrorTextBox;
    public Staff (Form1 form1)
    {
       InitializeComponent();
        _form1ErrorTextBox = form1.ErrorTextBox;
    }
    public void PlayAll()
    {
        _form1ErrorTextBox.Text = "";
        if (Pressed_Notes.Count == 0) {
            _form1ErrorTextBox.Text = "There are no music notes to play!";
        }  else {
            //Play the music notes
        }
    }
