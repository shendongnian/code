     private async void Start_Clicked(object sender, EventArgs e)
        {
            //do other operation
            progressbar1.Animate("SetProgress", (arg) => { progressbar1.Progress = arg; }, 8 * 60, 8 * 1000, Easing.Linear);
         
        }
        private void Stop_Clicked(object sender, EventArgs e)
        {
            if (progressbar1.AnimationIsRunning("SetProgress"))
            {
                progressbar1.AbortAnimation("SetProgress");
            }
        }
