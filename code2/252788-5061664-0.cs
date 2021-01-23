{
    public partial class FrmBupkis1 : Form
    {
        private PictureBox[] diceImages;
        private CheckBox[] holds;
        private Random rnd = new Random();
        public FrmBupkis1()
        {
            InitializeComponent();
            diceImages = new PictureBox[6];
            diceImages[0] = pbxDie0;
            diceImages[1] = pbxDie1;
            diceImages[2] = pbxDie2;
            diceImages[3] = pbxDie3;
            diceImages[4] = pbxDie4;
            diceImages[5] = pbxDie5;
            holds = new CheckBox[6];
            holds[0] = chbHold0;
            holds[1] = chbHold1;
            holds[2] = chbHold2;
            holds[3] = chbHold3;
            holds[4] = chbHold4;
            holds[5] = chbHold5;
        }
        private void rollBtn_Click(object sender, EventArgs e)
        {
            //First Check for first roll, if true skip hold checks and roll all dice
            //If false, Try the following ( 'lock' newly held dice (somehow) AND roll unheld dice )
            //If no dice are held, throw exception
                for (int i = 0; i < 6; i++)
                {
                    //if die is not held, then assign random number to image box
                    if (holds[i].Checked == false)
                        diceImages[i].Image = iglDice.Images[rnd.Next(6)];
                }
                try
                {
                    bool foundHeldDie = false;
                    for (int i = 0; i < 6; ++i)
                    {
                        // Sets foundHeldDie to true if appropriate
                        if (holds[i].Checked == true)
                        Enabled = true;
                    }
                    if (!foundHeldDie)
                    {
                        // throw the exception
                        Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    // handle the exception
                    MessageBox.Show("You must roll at least ONE scoring dice before your next roll.", "Error");
                }
                
            }
        private void gameOverBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                diceImages[i].Image = null;
                holds[i].Checked = false;
                holds[i].Enabled = true;
            }
        }
        private void quitBtn_Click(object sender, EventArgs e)
        {
            //btnQuit
            this.Close();
        }
    }
}
