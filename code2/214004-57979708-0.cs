        private bool CurrentlyFlashing = false;
        private async void FlashControl(Control control)
        {
            Color flashColor = Color.Yellow;
            float duration = 500; // milliseconds
            int steps = 10;
            float interval = duration / steps;
            if (CurrentlyFlashing) return;
            CurrentlyFlashing = true;
            Color original = control.BackColor;
            float interpolant = 0.0f;
            while (interpolant < 1.0f)
            {
                Color c = InterpolateColour(flashColor, original, interpolant);
                control.BackColor = c;
                await Task.Delay((int) interval);
                interpolant += (1.0f / steps);
            }
            control.BackColor = original;
            CurrentlyFlashing = false;
        }
        public static Color InterpolateColour(Color c1, Color c2, float alpha)
        {
            float oneMinusAlpha = 1.0f - alpha;
            float a = oneMinusAlpha * (float)c1.A + alpha * (float)c2.A;
            float r = oneMinusAlpha * (float)c1.R + alpha * (float)c2.R;
            float g = oneMinusAlpha * (float)c1.G + alpha * (float)c2.G;
            float b = oneMinusAlpha * (float)c1.B + alpha * (float)c2.B;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
