    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        DrawWord(e.Graphics);
    }
    private void btnInputLetter_Click(object sender, EventArgs e)
    {
        //Invokes the checkletter method to compare inputted char to that of the word
        CheckLetter(char.Parse(tbGuessedLetter.Text));
        //Redraws 
        Invalidate();
    }
