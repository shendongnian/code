        private int _counter = 0;
        public int counter
        {
           get { return _counter; }
           set { _counter = value; UpdateLabel(); }
        }
    
    private void UpdateLabel()
    {
       label1.Text = "Counter is: " + counter + " Last updated: " + DateTime.Now.ToShortTimeStrong();
    }
