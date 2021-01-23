        private void OnFadeTimerEvent(object sender, ElapsedEventArgs e) // Aufruf der Methode aus dem Worker-Thread
        {
            this.Invoke(new Action(() => FadeOutLabel()));
        }
        private void FadeOutLabel()
        {
            if (labelStartHelp.ForeColor.GetBrightness() <= 0.01)
            {
                FadeTimer.Enabled = false;
                labelStartHelp.Visible = false;
                return;
            }
            HslColor hsl = new HslColor(labelStartHelp.ForeColor);
            hsl.L -= 0.002; // Brightness is here lightness
            labelStartHelp.ForeColor = (System.Drawing.Color)hsl.ToRgbColor();
        }
