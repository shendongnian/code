        private void demoButton_MouseHover(object sender, EventArgs e)
        {
            if (sender != lastOver)
            {
                lastOver = (Button)sender;
                if (!transitionProgress.ContainsKey(lastOver))
                {
                    transitionProgress[lastOver] = 0.0;
                }
            }
        }
        private void demoButton_MouseLeave(object sender, EventArgs e)
        {
            lastOver = null;
        }
