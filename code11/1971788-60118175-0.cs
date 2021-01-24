private int clickCounter = 0;
        private void btnFillo_Click(object sender, EventArgs e)
        {
            if(clickCounter == 0 ) {
                // first time click
                btnFillo.Text = "text";
                clickCounter++;
            }
            else if (clickCounter == 1)
            {
                // second time click
                btnFillo.Text = "heeeeellll";
                clickCounter++;
            }
            else if (clickCounter == 2)
            {
                // third time click
                btnFillo.Text = "change 2";
                clickCounter = 0;
            }
            else // you can do more if you want more clicks
            {
                clickCounter += 1;
            }
        }
