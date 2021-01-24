    public class MainWindow: Form {
        public MainWindow()
        {
            this.Build();
        }
        void AddButtons()
        {
            var pnlButtons = new Panel();
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(370, 59);
            pnlButtons.BackColor = Color.White;
            int xPos = 0;
            int yPos = 0;
            // assign number of buttons = 27
            var btnArray = new System.Windows.Forms.Button[27];
            // Create (27) Buttons:
            int n = 0;
            while (n < 27)
            {
                btnArray[n] = new System.Windows.Forms.Button();
                btnArray[n].Tag = n + 1; // Tag of button
                btnArray[n].Width = 28; // Width of button
                btnArray[n].Height = 24; // Height of button
                // Location of button:
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Add buttons to a Panel:
                //To change Panel Buttons from Vertical to Horizontal move the multiplier from pnlButtons.Height to pnlButtons.Width
                pnlButtons.Height = btnArray[n].Height * 27;
                pnlButtons.Width = btnArray[n].Width;
                pnlButtons.Controls.Add(btnArray[n]); // Let panel hold the Buttons
                yPos = yPos + btnArray[n].Height; //For Vertical buttons
                //xPos = xPos + btnArray[n].Width; // For Horizontal buttons
                // Write English Character:
                char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 
                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 
                'W', 'X', 'Y', 'Z', '*'};
                btnArray[n].Text = Alphabet[n].ToString();
                this.Tabs.TabPages[ 1 ].Controls.Add(pnlButtons);
                // the Event of click Button
                btnArray[n].Click += (o, evt) => this.OnButtonClicked();
                n++;
            }
        }
    
        TabControl BuildTabs()
        {
            this.Tabs = new TabControl { Dock = DockStyle.Fill };
            this.Tabs.SelectedIndexChanged += (o, evt) => this.OnTabChanged();
            this.Tabs.TabPages.Add( new TabPage{ Text = "Tab1" } );
            this.Tabs.TabPages.Add( new TabPage{ Text = "Tab2" } );
            return this.Tabs;
        }
        void Build()
        {
            this.MinimumSize = new Size( 580, 460 );
            this.Text = "Programmatic creation";
            this.Controls.Add( this.BuildTabs() );
        }
        void OnButtonClicked()
        {
            MessageBox.Show( "Button clicked!" );
        }
        void OnTabChanged()
        {
            if ( this.Tabs.SelectedIndex == 1 ) {
                this.AddButtons();
            }
        }
        public TabControl Tabs {
            get; private set;
        }
    }
