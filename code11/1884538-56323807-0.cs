    public enum WinMethod
    {
        Horizontal,
        Vertical,
        Diagonal,
    }
    public enum Player
    {
        Yellow,
        Red,
    }
    public partial class Form1 : Form
    {
        Player turn = Player.Red;
        int turn_count = 0; //counts each turn for features such as draw function 
        bool winner_found = false; // automatically sets winner found function to false to 
        private WinMethod win_method;
        private Dictionary<Player, int> _winnerCount = new Dictionary<Player, int>()
        {
            { Player.Yellow, 0 },
            { Player.Red, 0 },
        };
        public Form1()
        {
            InitializeComponent();
        }
        private static Random __rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            win_method =
                new[] { WinMethod.Horizontal, WinMethod.Vertical, WinMethod.Diagonal }
                    .OrderBy(_ => __rnd.Next())
                    .First();
        }
        // function to alternate turns between red and yellow players and count turns for potential draws (see below). 
        // Also run checkForWinner function after every move (button click)
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = turn == Player.Red ? Color.Red : Color.Yellow;
            turn = turn == Player.Red ? Player.Yellow : Player.Red;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }
        private void checkForWinner()
        {
            var grid = new[]
            {
                new { line = new [] { A1, A2, A3, A4, A5 }, method = WinMethod.Horizontal },
                new { line = new [] { B1, B2, B3, B4, B5 }, method = WinMethod.Horizontal },
                new { line = new [] { C1, C2, C3, C4, C5 }, method = WinMethod.Horizontal },
                new { line = new [] { D1, D2, D3, D4, D5 }, method = WinMethod.Horizontal },
                new { line = new [] { E1, E2, E3, E4, E5 }, method = WinMethod.Horizontal },
                new { line = new [] { A1, B1, C1, D1, E1 }, method = WinMethod.Vertical },
                new { line = new [] { A2, B2, C2, D2, E2 }, method = WinMethod.Vertical },
                new { line = new [] { A3, B3, C3, D3, E3 }, method = WinMethod.Vertical },
                new { line = new [] { A4, B4, C4, D4, E4 }, method = WinMethod.Vertical },
                new { line = new [] { A5, B5, C5, D5, E5 }, method = WinMethod.Vertical },
                new { line = new [] { A1, B2, C3, D4, E5 }, method = WinMethod.Diagonal },
                new { line = new [] { E1, D2, C3, B4, A5 }, method = WinMethod.Diagonal },
            };
            winner_found =
                grid.Any(g => g.method == win_method && g.line.Select(x => x.BackColor).Distinct().Count() == 1);
            if (winner_found)
            {
                disableButtons();
                _winnerCount[turn] += 1;
                (turn == Player.Red ? red_win_count : yellow_win_count).Text = _winnerCount[turn].ToString();
            }
            else
            {  // if all squares are filled (25 moves) than signal draw as no more moves can be made
                if (turn_count == 25)
                    MessageBox.Show("Draw! Wanna rematch?", "Rematch!");
            }
        }
        // function to disable all buttons for when winner is detected
        private void disableButtons()
        {
            foreach (Button b in Controls.OfType<Button>())
            {
                b.Enabled = false;
            }
        }
        // help -> how to play: instructions on how to play the game in brief terms
        private void howToPlayToolStripMenuItem_click(object sender, EventArgs e)
        {
            MessageBox.Show("Connect Five is quite similar to the good old-fashioned Connect Four, " +
                "but there is a lot more spaces for you to play you pieces and you have to connect " +
                "five to win! The twist is, that you can only win a certain way, dependent on the " +
                "randomly generated direction on the right hand side of the screen. If the direction is " +
                "vertical, then you can only win with 5 coloured squares in a vertical line. Same with " +
                "horizontal and diagonal directions! Have Fun!", "Connect Five: How To Play");
        }
        // help -> about: quick about menu of the game, creator and copyright year/ symbol
        private void aboutToolStripMenuItem_click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Brendan Ellis © 2019", "Connect Five About");
        }
        // visual studio has a hissy fit if i dont put this in because it recognises this as a menu strip. 
        // This and the button_click function clash and i haven't been able to find a fix.
        private void fileToolStripMenuItem_click(object sender, EventArgs e)
        {
        }
        // file -> new game: resets complete game board to have a rematch
        private void newGameToolStripMenuItem_click(object sender, EventArgs e)
        {
            turn = Player.Red;
            turn_count = 0;
            win_method =
                new[] { WinMethod.Horizontal, WinMethod.Vertical, WinMethod.Diagonal }
                    .OrderBy(_ => __rnd.Next())
                    .First();
            foreach (Button b in Controls.OfType<Button>())
            {
                b.Enabled = true;
                b.BackColor = Color.LightGray;
            }
        }
        // file -> exit game: just exits the game because clicking the cross is obviously sooooo last year
        private void exitGameToolStripMenuItem_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // visual studio has a hissy fit if i dont put this in because it recognises this as a menu strip. 
        // This and the button_click function clash and i haven't been able to find a fix.
        private void helpToolStrip_click(object sender, EventArgs e)
        {
        }
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.BackColor = turn == Player.Yellow ? Color.Yellow : Color.Red;
            }
        }
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.BackColor = Color.LightGray;
            }
        }
        private void resetWinCountersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yellow_win_count.Text = "0";
            red_win_count.Text = "0";
        }
    }
