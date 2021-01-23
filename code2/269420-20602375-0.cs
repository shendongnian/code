    private void timer1_Tick(object sender, EventArgs e)
        {
            // timer interval set to 10 to ensure smooth fading
            // declared int: r = 0, g = 215 and b = 180
            // target values are r = 32, g = 32 and b = 32 to match BackColor
            fade++;
            if (fade >= 500) // arbitrary duration set prior to initiating fade
            {
                if (r < 32) r++; // increase r value with each tick
                if (g > 32) g--; // decrease g value with each tick
                if (b > 32) b--; // decrease b value with each tick
                label1.ForeColor = Color.FromArgb(255, r, g, b);
                if (r == 32 && g == 32 && b == 32) // arrived at target values
                {
                    // fade is complete - reset variables for next fade operation
                    label1.ForeColor = Color.FromArgb(255, 0, 215, 180);
                    label1.Text = "";
                    fade = 0;
                    r = 0;
                    g = 215;
                    b = 180;
                    timer1.Enabled = false;
                }
            }
        }
