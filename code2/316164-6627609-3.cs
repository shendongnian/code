    public class CreditCardWaitWindow : Form
    {
      private async void Form_Load(object sender, EventArgs args)
      {
        await CheckForCardsPresenceAsync();
        RaiseEvent();
      }
      private Task CheckForCardsPresenceAsync()
      {
        return Task.Factory.StartNew(
          () =>
          {
            while (true)
            {
              Thread.Sleep(3000);
              if (CheckCardsPresence()) break;
            }
          }, TaskCreationOptions.LongRunning);
      }
    }
