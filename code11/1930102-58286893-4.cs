    public partial class Form1 : Form
        {
            /// <summary>
            /// a list of colors to control the sequence
            /// </summary>
            Color[] colorsList = { Color.Coral, Color.AliceBlue, Color.DarkRed, Color.Red, Color.Blue, Color.Aquamarine };
    
            /// <summary>
            /// Timer to control the execution time of the color change
            /// </summary>
            System.Timers.Timer myTimer = new System.Timers.Timer();
            public Form1()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// Load or Main of class
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Form1_Load(object sender, EventArgs e)
            {
                this.BackColor = colorsList[0];
                myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                myTimer.Interval = 5000;
                myTimer.Start();
            }
    
            /// <summary>
            /// method that changes the color, executed by the timer
            /// </summary>
            /// <param name="source"></param>
            /// <param name="e"></param>
            private void OnTimedEvent(object source, ElapsedEventArgs e)
            {            
                for (int i = 0; i < colorsList.Length; i++)
                {
                    if (this.BackColor == colorsList[i])
                    {
                        if (i < colorsList.Length - 1)
                        {
                            this.BackColor = colorsList[i + 1];
                            break;
                        }
                        else
                        {
                            //return to the first color
                            this.BackColor = colorsList[0];
                            break;
                        }
                    }
                }
            }
        }
