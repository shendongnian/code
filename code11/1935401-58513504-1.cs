    private void button1_Click(object sender, EventArgs e)
    {
        double startingPop;
        double increasePer;
        double numDays;
        
        const int INTERVAL = 1;
        
        if (double.TryParse(textBox1.Text, out startingPop) &&
            double.TryParse(textBox2.Text, out increasePer) &&
            double.TryParse(textBox3.Text, out numDays))
        {
            Results.Items.Add("On the first day, the amount of organisms is " + startingPop);
            for (int i = 1; i <= numDays; i += INTERVAL)
            {
                startingPop = (startingPop * (increasePer / 100) + startingPop);
                Results.Items.Add("After " + i + " day(s), the amount of organisms is " + startingPop);
            }
        }
    }
