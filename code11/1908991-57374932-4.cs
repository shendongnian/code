        private List<Panel> _panels = new List<Panel>(); //class level list to track the panels
        private void button2_Click(object sender, EventArgs e)
        {
            //create a new panel when the button is clicked
            var p = new Panel();
            p.Size = new Size(10, 10);
            p.Location = new Point(10, DateTime.Now.Second * (this.Height / 60)); //"random" Y so they don't pile up
            p.BackColor = Color.Green;
            this.Controls.Add(p);                             //add panel to form
            _panels.Add(p);                                   //add panel to list
            timer1.Enabled = true;                            //animate
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = _panels.Count - 1; i >= 0; i--)    //use a backwards int indexed loop because we are potentially removing items from the list. 
            {                                               //Working backwards is the easiest way to not have to fiddle the index upon removal
                var p = _panels[i];                         //temp reference to a panel in the list, not related to 'var p' in the button click
                p.Left += 25;                               //move it
                if (p.Left > this.Width)                    //panel that is off screen?
                    _panels.RemoveAt(i);                    //stop moving it then
            }
            if (_panels.Count == 0) //no more panels to move?
                timer1.Stop();      //stop the timer
        }
