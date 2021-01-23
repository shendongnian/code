        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnButton.Click += btnButton_Click;
            // OR
            btnButton.Click += (sender, e)=> { // Button clicked! Do something };
        }
        protected void btnButton_Click(object sender, EventArgs e)
        {
             // Your button has been clicked, Do something
        }
