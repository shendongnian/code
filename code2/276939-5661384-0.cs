           Boolean isButtonClicked;
           
            protected override void OnPaint(PaintEventArgs e)
            {
                if (this.isButtonClicked)
                {
                    this.isButtonClicked = false;
                    // some paint logic goes down here...
                    e.Graphics.FillEllipse(Brushes.YellowGreen, 12, 12, 54, 54);
                }
            }
    
            private void HandleOnButtonClick(Object sender, EventArgs e)
            {
                this.isButtonClicked = true;
                this.Invalidate();
            }
