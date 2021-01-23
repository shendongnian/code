    private void button1_Click(object sender, EventArgs e)
            {
                this.ActiveControl.BackColor = controlColor;
                this.ActiveControl.Text = controlNumber;
                allCellsClicked[0] = '1';
                checkGuess();
            }
    
    private void button2_Click(object sender, EventArgs e)
            {
                this.ActiveControl.BackColor = controlColor;
                this.ActiveControl.Text = controlNumber;
                allCellsClicked[0] = '2';
                checkGuess();
            }
    
    private void checkGuess(){
           if (all_Buttons_Clicked())
                {
                    allCellsClicked[0] = '0';
                    allCellsClicked[1] = '0';
                    allCellsClicked[2] = '0';
                    allCellsClicked[3] = '0';
                    button04.Enabled = false;
                    button03.Enabled = false;
                    button02.Enabled = false;
                    .....
                }
