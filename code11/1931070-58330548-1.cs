namespace Whack_a_mole
{
    public partial class Form1 : Form
    {
        private Random _rng = new Random(); //used to determine mole sleep and wake times
        private Timer _t = new Timer(); //ticks ever 0.1 s
        private List<Button> _buttons = new List<Button>(); //track our mole buttons
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
            _t.Start(); //start the timer
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //every 0.1 s we scan the board poke every mole
            foreach(Button b in _buttons){
              b.Enabled = (b.Tag as Mole).IsAwake(); //isawake will sometimes wake a mole up or put it to sleep if we didnt whack it soon enough
              if(b.Enabled) //if the mole is awake
                b.BackColor = Color.Red; //red tbuton = awake mole
              else
                b.BackColor = Color.Gray; //sleeping mole
            }
        }
  
        private void MoleButton_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button); //many buttons share this handler; which button was clicked?
            Mole m = (b.Tag as Mole); //get the mole for that button
            m.Whack(); //whack it - puts to sleep and resets the sleep timer
            b.Enabled = false; //turn this button off
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
            button.Tag = new Mole(_rng); //associate a mole with the button
            button.BackColor = Color.Gray;
            button.Enabled = false;
            button.Click += MoleButton_Click; //all mole buttons handled by the smae click handler
            this.Controls.Add(button);
        }
    }
}
  //mole is a thing that has a counter, we decrement every 0.1 seconds by asking IsAwake()
 // the mole may wake up, and it is awake for another random time then sleeps again
  class Mole{
    //count the whacks. will put this on a button text hence public
    public int WhackCounter{get; set;}=0;
    private int _counter = 0; //this tracks how long the mole sleeps / wakes for
    private Random _r;
    private bool _awake = false; //this toggles every time the counter hits 0
    public Mole(Random r){
      _r = r;
      _counter = r.Next(1,100) //init to a random sleep time
    }
    public void Whack(){
      WhackCounter++; //up the whacks
      _counter = r.Next(10,100); //at tenths of a second it sleeps for 1 to 10 seconds
      _awake = false; //put to sleep
    }
    public bool IsAwake(){ //this method decrements the counter then returns if the mole is awake
      _counter--;
      if(_counter < 1){ //did we hit 0? cycle the mole state and re-randomize
        //toggle state
        _awake = !_awake;
        if(_awake)
          _counter = r.Next(20,50); //moles wake for between 2 and 5 seconds
        else
          _counter = r.Next(10,100);
      }
      return _awake;
    }
  }
