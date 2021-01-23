    public class CreditCardWaitWindow : Form
    {
      private System.Timers.Timer timer = new System.Timers.Timer();
      private void Form_Load(object sender, EventArgs args)
      {
        timer.Elapsed += OnElapsed;
        timer.Interval = 3000;
        timer.AutoReset = false;
        timer.Start();
      }
    
      private void OnElapsed(object sender, ElapsedEventArgs args)
      {
        if (CheckCardsPresence())
        {
          Invoke(
            (MethodInvoker)(() =>
            {
              RaiseEvent();
            }), null);
        }
        else
        {
          timer.Start();
        }
      }
    }
