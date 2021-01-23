    public partial class Form1 : Form
    {
        private bool isDragging;            //We use this to keep track that we are FakeDragging
        private Point startPosition;        //The start position of our "Fake" dragging action
        private double dragDistance = 0;    //The distance(absolute) from the drag action starting point    
        private const int MINIMUM_DRAG_DISTANCE = 100;  //minimum FakeDrag distance.
        private Label label1 = new Label();
        public Form1()
        {
            #region Support form generation code
                InitializeComponent();
                this.label1 = new System.Windows.Forms.Label();
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(54, 242);
                this.label1.Name = "Distance:";
                this.label1.Size = new System.Drawing.Size(35, 13);
                this.Controls.Add(label1);
                this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
                this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            #endregion
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if the mouse button is pressed then 
            //there's the chanche a dragAction
            //is being performed and we take note
            //of the position of the click
            //(we will use this later on the mouseMove event
            //to calculate the distance mouse has traveled
            if (e.Button.Equals(MouseButtons.Left))
                startPosition = e.Location;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ///at the mouse up event we can execute code that does something
            if (isDragging && dragDistance > MINIMUM_DRAG_DISTANCE)
            {
                MessageBox.Show("we have fakedragged!\nDo something useful here");
                //Do your Drag & Drop code here.
            }
            ///but WE MUST signal our system that the Fake Drag has ended
            ///and reset our support variables.
            this.Cursor = Cursors.Default;
            isDragging = false;
            dragDistance = 0;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ///when the mouse moves we control if the mouse button is still pressed.
            ///if it is so, we surely are FakeDragging and we set our boolean to true
            ///(it will be useful in the mouseUP event).
            ///Then we calculate the absolute distance the mouse has traveld since the
            ///user has pressed the left mouseButton.
            
                        
            Point currentPosition = e.Location;
            if (e.Button.Equals(MouseButtons.Left))
            {
                isDragging = true;
                dragDistance =
                    Math.Abs(
                        Math.Sqrt(
                            (
                                Math.Pow(
                                    (currentPosition.X - startPosition.X), 2)
                            +
                                Math.Pow(
                                    (currentPosition.Y - startPosition.Y), 2)
                            )));
            }
            //we set the label text displaying the distance we just calculated
            label1.Text = 
                String.Format(
                    "Distance: {0}", 
                    dragDistance.ToString());
            Application.DoEvents();
            ///At last, if the distance il greater than our offset, we change the 
            ///mouse cursor(this is not required in a real case scenario)
            if (dragDistance > MINIMUM_DRAG_DISTANCE)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }
    }
