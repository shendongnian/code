         private void AddButtons()
        {
            Panel pnlButtons = new Panel();
            pnlButtons.Location = new System.Drawing.Point(370, 59);
            pnlButtons.BackColor = Color.White;
            int xPos = 0;
            int yPos = 0;
            // assign number of buttons = 27
            btnArray = new System.Windows.Forms.Button[27];
            // Create (27) Buttons:
            for (int i = 0; i < 27; i++)
            {
                // Initialize one variable
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;
            while (n < 27)
            {
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
                Controls.Add(pnlButtons);
                // the Event of click Button
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
        }
