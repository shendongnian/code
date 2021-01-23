        protected void PeanutGuess_click(object sender, EventArgs e) {
            PeanutButter.WebService1 pb = new PeanutButter.WebService1();
            string response = pb.Guess(10);
            lblResult.Text = string.Format("Response for 10 is " + response);
        }
