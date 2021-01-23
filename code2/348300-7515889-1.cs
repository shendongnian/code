        private void FadeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity -= .08; //Decrease opacity
            if (this.Opacity <= 0) //While it is not 0
            {
                FadeOut.Stop(); //Stop!
                this.Close(); //Close the form
            }
        }
