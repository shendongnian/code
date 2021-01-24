    public class Whatever{
      private Timer _t = new Timer();
      private DateTime _start;
      public Whatever(){ //constructor
        _t.Elapsed += TimerElapsed; //elapsed event handled by TimerElapsed method
        _t.Interval = 1000; //fire every second 
      }
      public void StartGame(){
        _start = DateTime.UtcNow;
        _t.Start();
      }
      private void TimerElapsed(){
        Console.WriteLine("Game has been running for " + (DateTime.UtcNow - _start));
      }
