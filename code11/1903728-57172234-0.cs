    public partial class Form1 : Form
    {
        PictureBox pictureBox1;
        Panel panel1;
    
        public Form1()
        {
            InitializeComponent();
            Size = new Size(500, 500);
            Controls.Add(new TextBox() { TabIndex = 0, Location = new Point(350, 5)});
            panel1 = new Panel() {Size = new Size(300, 300), Location = new Point(5, 5), BorderStyle = BorderStyle.FixedSingle,Parent = this, AutoScroll = true};
            pictureBox1 = new PictureBox() {Size = new Size(200, 200) , Location = new Point(5,5), BorderStyle = BorderStyle.FixedSingle, Parent = panel1};
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            panel1.MouseWheel += panel1_MouseWheel;
        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // On Win10 with "Scroll inactive windows when I hover over them" turned on,
            // this would not be needed for pictureBox1 to receive MouseWheel events
                            
            pictureBox1.Select(); // activate the control
            // this makes pictureBox1 the form's ActiveControl
            // you could also use: 
            //   this.ActiveControl = pictureBox1;
        }
    
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Rectangle r = pictureBox1.Bounds;
            int sizeStep = Math.Sign(e.Delta) * 10;
            r.Inflate(sizeStep, sizeStep);
            r.Location = pictureBox1.Location;
            pictureBox1.Bounds = r;
    
            // e is an instance of HandledMouseEventArgs
            HandledMouseEventArgs hme = (HandledMouseEventArgs)e;
            // setting to true prevents the bubbling of the event to the containing control (panel1)
            hme.Handled = true;
            // comment out the above line to observe panel1_MouseWheel
            // being called
        }
    
    
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.Print("bubbled wheel event");
        }
    }
