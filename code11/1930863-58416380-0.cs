private void timer3_Tick(object sender, EventArgs e)
        {
            TimeSpan idleTime = TimeSpan.FromMinutes(0.5);
            TimeSpan aa = TimeSpan.FromSeconds(1);
            if (UserInput.IdleTime >= idleTime && timer1.Enabled)
            {
                timer2.Start();
                timer1.Stop();
                Console.WriteLine("Stopped Timer 1, Start Timer 2 ");
            }
            else if (UserInput.IdleTime < aa && timer2.Enabled)
            {
                timer1.Start();
                timer2.Stop();
                Console.WriteLine("Stopped Timer 2, Start Timer 1 ");
            }
            Console.WriteLine("Idle for " + UserInput.IdleTime.ToString());
        }
