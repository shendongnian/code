    const int TIME_LIMIT = 50000; // set to whatever you need
    int timeout;
    Timer Timer1;
    void Form1() {
       Timer1 = new Timer();
       Timer1.Interval = 200; // 200 milliseconds
       Timer1.Tick += new EventHandler(Timer_Tick);
    }
    void ShowSubPanel() {
      Timer_Reset();
      panelSub1.BringToFront();
    }
    void Timer_Reset() {
      Timer_Stop();
      Timer_Start();
    }
    void Timer_Start() {
      timeout = 0;
      Timer1.Start();
    }
    void Timer_Stop() {
      Timer1.Stop();
    }
    void Timer_Tick() {
      if (TIME_LIMIT < timeout++) {
        Timer_Stop();
        // Here, call your Main Form
        Main.BringToFront(); // I use Panels instead of forms
      }
    }
