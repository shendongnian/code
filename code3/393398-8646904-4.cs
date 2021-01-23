    //create this field and property before the constructor
    public int counter;
    public int Counter
    {
        get { return counter; }
        set { counter = value; }
    }
    //button click sets the interval to 1sec, starts timer and sets the int Counter to 0
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Interval = 1000;
        timer1.Start();
        Counter = 0;
    }
    //the tick event iterates the Counter property +1 everytime the timer advances 1sec and while Counter is under 5 for example it creates those objects
    private void timer1_Tick(object sender, EventArgs e)
    {
        Counter++;
        while (counter < 5)
        {
            DrawMap ortamcizdir = new DrawMap(p_box_map, bmp, ZoomControl, panel1);
            DrawCell hucrecizdir = new DrawCell (p_box_map, bmp, a, ZoomControl, ZoomKontrolBolen);
        }
    }
