queueTimer.Tick += new ElapsedEventHandler(queueTimer_Tick); 
void queueTimer_Tick(object sender, EventArgs e)
{
	CustomerQueue.Arrive();
}
