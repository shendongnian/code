    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public partial class Form1 : Form
    {
        private Button previousButton = null;
        public Form1()
        {
            InitializeComponent();
            button1.Click += Buttons_Click;
            button2.Click += Buttons_Click;
            button1.Tag = new Coord(0, 0);
            button2.Tag = new Coord(1, 0);
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            if (previousButton != null)
            {
                // do something with previousButton
                Coord prevCoords = (Coord)(previousButton.Tag);
                MessageBox.Show($"previous coords {prevCoords.X} {prevCoords.Y}");
            }
            // code to work with the currently clicked button
            // as (Button)sender
            Coord currentCoords = (Coord)((Button)sender).Tag;
            MessageBox.Show($"current coords {currentCoords.X} {currentCoords.Y}");
            // remember the current button
            previousButton = (Button)sender;
        }
    }
