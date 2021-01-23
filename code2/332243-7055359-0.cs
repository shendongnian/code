    private DateTime GetNextSleep()
    {
        // Between 3 and 20 minutes, adjust as needed.
        return DateTime.Now + new TimeSpan(0, 0,
            RandomNumber(60 * 3, 60 * 20));
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //this section sends data to the number validation function
        string ValidateNum = NumberOfItems.Text;
        NumberCheck(ValidateNum);
        int Clicks = Convert.ToInt16(NumberOfItems.Text);
        DateTime nextSleep = GetNextSleep();
        for (int i = 1; i < Clicks; i++)
        {
            int SleepTime1 = RandomNumber(819, 1092);
            DoMouseClickLeft();
            Thread.Sleep(SleepTime1);
            DoMouseClickLeft();
            Thread.Sleep(SleepTime1);
            if (DateTime.Now >= nextSleep)
            {
                // Sleep between 1 and 5 minutes, adjust as needed.
                Thread.Sleep(new TimeSpan(0, 0,
                    RandomNumber(60 * 1, 60 * 5)));
                nextSleep = GetNextSleep();
            }
        }
    }
