        private void styleUpdate_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < transitionProgress.Count; i++)
            {
                Button button = transitionProgress.Keys.ElementAt(i);
                bool changing = false;
                if (button == lastOver)
                {
                    if (transitionProgress[button] < 1.0)
                    {
                        transitionProgress[button] = Math.Min(1.0, transitionProgress[button] + step);
                        changing = true;
                    }
                }
                else
                {
                    if (transitionProgress[button] > 0.0)
                    {
                        transitionProgress[button] = Math.Max(0.0, transitionProgress[button] - step);
                        changing = true;
                    }
                }
                if (changing)
                {
                    double progress = transitionProgress[button];
                    button.BackColor = Color.FromArgb(
                        (int)Math.Floor((endColor.R - startColor.R) * progress + startColor.R),
                        (int)Math.Floor((endColor.G - startColor.G) * progress + startColor.G),
                        (int)Math.Floor((endColor.B - startColor.B) * progress + startColor.B)
                        );
                }
            }
        }
