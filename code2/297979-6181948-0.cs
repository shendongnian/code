        //This would be your FormLoad event or somewhere else where you initialize your form information
        private void form_load()
        {
            enterTimer.Interval = 10;
            enterTimer.Tick += new EventHandler(enterTimer_Tick);
            leaveTimer.Interval = 10;
            leaveTimer.Tick += new EventHandler(leaveTimer_Tick);
        }
        private void setForm()
        {
            this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width, Screen.GetWorkingArea(this).Height - this.Height);
        }
        Timer enterTimer;
        Timer leaveTimer;
        private void B00nZPictureBox_MouseEnter(object sender, EventArgs e)
        {
            enterTimer.Start();
        }
        private void B00nZ_MouseLeave(object sender, EventArgs e)
        {
            leaveTimer.Start();
        }
        void enterTimer_Tick(object sender, EventArgs e)
        {
            //Put your enter logic here
        }
        void leaveTimer_Tick(object sender, EventArgs e)
        {
            //Put your leave logic here
        }
