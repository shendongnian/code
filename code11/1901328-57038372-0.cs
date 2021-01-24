    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }
        string x = "right";
        private void Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                x = "up";
            }
            else if (e.KeyCode == Keys.S)
            {
                x = "down";
            }
            else if (e.KeyCode == Keys.D)
            {
                x = "right";
            }
            else if (e.KeyCode == Keys.A)
            {
                x = "left";
            }
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
    
            if (x == "up")
            {
                Player.Location = new System.Drawing.Point(Player.Location.X, Player.Location.Y - 10);
            }
            if (x == "down")
            {
                Player.Location = new System.Drawing.Point(Player.Location.X, Player.Location.Y + 10);
            }
            if (x == "right")
            {
                Player.Location = new System.Drawing.Point(Player.Location.X + 10, Player.Location.Y);
            }
            if (x == "left")
            {
                Player.Location = new System.Drawing.Point(Player.Location.X - 10, Player.Location.Y);
            }
    
        }
    
    }
