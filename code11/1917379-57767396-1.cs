lang-cs
private bool isRed;
private static System.Timers.Timer g_shock = new System.Timers.Timer();
public UI()
{
	g_shock.Elapsed += ManageOnPaint;
	g_shock.Interval = 1000;
	g_shock.Start();
}
private void ManageOnPaint(object sender, System.Timers.ElapsedEventArgs elapsed)
{
	if (isRed)
	{
		// Set ellipse color non red			
	}
	if (!isRed)
	{
		// Set ellipse color red
	}
	
	// Toggle isRed
	isRed = !isRed;
}
protected override void OnPaint(PaintEventArgs e)
{
    /// paint ellipse with current ellipse color
}
