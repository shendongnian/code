        Timer timer = new Timer();
        timer.Interval = 500;
        timer.Tick += (t, args) =>
            {
                timer.Enabled = false;
                /* some code */
            };
        timer.Enabled = true;
