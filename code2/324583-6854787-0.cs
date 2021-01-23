            this.myButton.Click += new System.EventHandler(this.TriggerMyButtonClickedEvn);
        public event EventHandler myButtonClickedEvn;
        private void TriggerMyButtonClickedEvn(object sender, EventArgs e)
        {
            if (myButtonClickedEvn != null)
                myButtonClickedEvn(sender, e);
        }
