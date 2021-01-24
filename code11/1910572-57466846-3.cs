        void AddButtons()
        {
            TabPage tabPage1 = this.Tabs.TabPages[ 1 ];
            if ( tabPage1.Controls.Count == 0 ) {
                var pnlButtons = new TableLayoutPanel();
                pnlButtons.Dock = DockStyle.Fill;
                pnlButtons.AutoScroll = true;
                // assign number of buttons = 27
                var btnArray = new Button[27];
                // Create (27) Buttons:
                for(int n = 0; n < 27; ++n)
                {
                    btnArray[n] = new Button{ Tag = n + 1 };
                    // Add buttons to a Panel:
                    //To change Panel Buttons from Vertical to Horizontal move the multiplier from pnlButtons.Height to pnlButtons.Width
                    pnlButtons.Controls.Add(btnArray[n]); // Let panel hold the Buttons
                    // Write English Character:
                    btnArray[n].Text = char.ToString( (char) ( 'a' + n ) );
                    tabPage1.Controls.Add(pnlButtons);
                    // the Event of click Button
                    btnArray[n].Click += (o, evt) => this.OnButtonClicked();
                }
            }
        }
