private int p;
Random m = new Random();
Random n = new Random();
void aim()
{
	p = n.Next(2, 5);
	OppScore.Text = (string.Format("Target Score: {0}", p));
}
public void RunTimer_Tick(object sender, EventArgs e)
{
	target();
	if (lives <= 0)
	{
		left--;
		lives = 2;
		TimesLeft.Text = (string.Format("attempts left: {0}", left));
		TimesLeft.Text = Convert.ToString(left);
	}
	if (left <= 0)
	{
		this.Hide();
		new Game_Over().Show();
		RunTimer.Stop();
	}
	if (counter < 1)
	{
		aim();
		counter++;
	}
	if (score > p)
	{
		this.Hide();
		new Winner().Show();
		RunTimer.Stop();
	}
}
In the code above you can see that by declaring the variable outside the method and within the class your variable gets visible to all methods within the class.
private int p;
