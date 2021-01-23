    public MDIParent1()
            {
                InitializeComponent();
                foreach (var ctl in this.Controls)
                {
                    if (ctl is MdiClient)
                    {
                        (ctl as MdiClient).GotFocus  += Client_gotfocus;
                        (ctl as MdiClient).LostFocus  += Client_lostfocus;
                        break;
                    }
                }
    
            }
            private void Client_gotfocus(object sender, EventArgs e)
            {
                button1.BringToFront();
            }
            private void Client_lostfocus(object sender, EventArgs e)
            {
                button1.SendToBack ();
            }
