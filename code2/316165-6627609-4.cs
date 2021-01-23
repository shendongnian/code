    public class CreditCardWaitWindow : Form
    {
      private System.Windows.Timer timer = new System.Windows.Timer();
      private void Form_Load(object sender, EventArgs args)
      {
        timer.Tick += OnTick;
        timer.Interval = 3000;
        timer.Start();
      }
    
      private void OnTick(object sender, EventArgs args)
      {
        if (CheckCardsPresence())
        {
          RaiseEvent();
          timer.Stop();
        }
      }
    }
