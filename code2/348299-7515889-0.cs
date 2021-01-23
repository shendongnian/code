        private void FadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += .08;
            if (this.Opacity >= 1)
            {
                FadeIn.Stop();
            }
        }
