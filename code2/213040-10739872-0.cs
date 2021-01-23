    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    class RepeatingButton : Button
    {
        public RepeatingButton()
        {
            internalTimer = new System.Windows.Forms.Timer();
            internalTimer.Interval = FirstDelay;
            internalTimer.Tick += new EventHandler(internalTimer_Tick);
            this.MouseDown += new MouseEventHandler(RepeatingButton_MouseDown);
            this.MouseUp += new MouseEventHandler(RepeatingButton_MouseUp);
        }
        public int FirstDelay = 500;
        public int LoSpeedWait = 300;
        public int HiSpeedWait = 100;
        public int LoHiChangeTime = 2000;
        void RepeatingButton_MouseDown(object sender, MouseEventArgs e)
        {
            //this.OnClick(e);
            internalTimer.Tag = DateTime.Now;
            internalTimer.Start();
        }
        void RepeatingButton_MouseUp(object sender, MouseEventArgs e)
        {
            internalTimer.Stop();
            internalTimer.Interval = FirstDelay;
        }
        void internalTimer_Tick(object sender, EventArgs e)
        {
            this.OnClick(e);
            TimeSpan elapsed = DateTime.Now - ((DateTime)internalTimer.Tag);
            if (elapsed.TotalMilliseconds < LoHiChangeTime)
            {
                internalTimer.Interval = LoSpeedWait;
            }
            else
            {
                internalTimer.Interval = HiSpeedWait;
            }
        }
        private System.Windows.Forms.Timer internalTimer;
    }
