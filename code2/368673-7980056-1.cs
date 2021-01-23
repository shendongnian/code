    private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan remainingTime = endTime - DateTime.UtcNow;
            if (remainingTime <= TimeSpan.Zero)
            {
                label1.Text = "Done!";
                timer1.Enabled = false;
                lock(threadObject){
                    Monitor.Pulse(threadObject); //You signal the thread, indicating that the condition has been met
                }
            }
            else
            {
               //...
            }
        }
