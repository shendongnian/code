csharp 
private static void delay(int Time_delay)
 {
   int i = 0;          
   _delayTimer = new System.Timers.Timer();
   _delayTimer.Interval = Time_delay;
   _delayTimer.AutoReset = false; 
   _delayTimer.Elapsed += (s, args) => i = 1;
   _delayTimer.Start();
   //This line wait the timer and freeze the UI
   while (i == 0) { };
}
The waiter is in the UI's thread and freeze the UI.
I think, you need asynchronous.
If you can use TPL (System.Threading.Task) :
private static async void delay(TimeSpan timeDelay, Action updateUI)
{
   //Wait some time without freeze the UI
   await Task.Delay(timeDelay);
   //Call updateUI on UI's thread
   updateUI();
}
