     private void Form1_Load(object sender, EventArgs e)
        {
            var list =  GetAllButtonControls();
            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    //Set text
                    control.Text += " Foo";
                }
            }
        }
        
        private List<Control> GetAllButtonControls()
        {
            List<Control> rlist = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    rlist.Add(control);
                }
                    
            }
            return rlist;
        }
