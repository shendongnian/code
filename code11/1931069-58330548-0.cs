namespace Whack_a_mole
{
    public partial class Form1 : Form
    {
        private Random _rng = new Random();
        private Timer _t = new Timer();
        private List<Button> _buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label1.Text = "Max size is 5";
            _t.Interval = 100;
            _t.Click += Timer_Tick;
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            _t.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach(Button b in _buttons){
              b.Enabled = (b.Tag as Mole).IsAwake();
              if(b.Enabled)
                b.BackColor = Color.Red;
              else
                b.BackColor = Color.Gray;
            }
        }
  
        private void MoleButton_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            Mole m = (b.Tag as Mole);
            m.Whack();
            b.Enabled = false;
            b.BackColor = Color.Gray;
            b.Text = m.WhackCounter.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Area = Convert.ToInt32(textBox1.Text);
            if (Area < 6)
            {
                GenerateGrid(20, 20, Area, Area, 75, 75);
            } else
            {
                label1.Visible = true;
            }
        }
        private void GenerateGrid(int gridleft, int gridtop, int horizontalCount, int verticalcount, int width, int height)
        {
            for (int i = 0; i < verticalcount; i++)
            {
                GenerateRowOfButtons(gridleft, gridtop+height*i, horizontalCount, width, height);
            }
        }
        private void GenerateRowOfButtons (int startX, int startY, int count, int width, int height)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateButton(startX+i*width, startY, width, height);
            }
        }
        private void GenerateButton (int x, int y, int width, int height)
        {
            Button button = new Button();
            button.Width = width;
            button.Height = height;
            button.Left = x;
            button.Top = y;
            button.Tag = new Mole(_rng);
            button.BackColor = Color.Gray;
            button.Enabled = false;
            button.Click += MoleButton.Click;
            this.Controls.Add(button);
        }
    }
}
  class Mole{
    public int WhackCounter{get; set;}=0;
    private int _counter = 0;
    private Random _r;
    private bool _awake = false;
    public Mole(Random r){
      _r = r;
      _counter = r.Next(1,100)
    }
    public void Whack(){
      WhackCounter++;
      _counter = r.Next(10,100); //at tenths of a second it sleeps for 1 to 10 seconds
      _awake = false;
    }
    public bool IsAwake(){
      _counter--;
      if(_counter < 1){
        //toggle state
        _awake = !_awake;
        if(_awake)
          _counter = r.Next(20,50); //moles wake for between 2 and 5 seconds
        else
          _counter = r.Next(10,100);
      }
    }
  }
