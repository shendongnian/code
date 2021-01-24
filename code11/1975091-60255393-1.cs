        public delegate void CreateArrowEventArgs(Arrow arrow);
        public event CreateArrowEventArgs OnCreateArrow; 
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.OnCreateArrow!=null)
            {
                // Create Arrow object which you will have access to in your Form
                Arrow arrowToDraw = new Arrow();
                // Fire The Event
                this.OnCreateArrow.Invoke(arrowToDraw);
            }
        }
