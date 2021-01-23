    private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
            {
                e.Control.Click += new EventHandler(Clicked);
            }
    
            private void Clicked(object sender, EventArgs e)
            {
                //click event code goes here
            }
