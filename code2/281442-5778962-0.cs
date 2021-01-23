    using System;
    using System.Windows.Forms;
    using System.Timers;
    using System.Drawing;
    namespace WinFormsAutoClose
    {
      public partial class Form1 : Form
      {
        int _countDown = 5;
        System.Timers.Timer _timer;
        public Form1()
        {
          InitializeComponent();
          _timer = new System.Timers.Timer(1000);
          _timer.AutoReset = true;
          _timer.Elapsed += new ElapsedEventHandler(ProcessTimerEvent);
          _timer.Start();
        }
        private void ProcessTimerEvent(Object obj, System.Timers.ElapsedEventArgs e) 
        {
          Invoke(new Action(() => { ProcessTimerEventMarshaled(); }));
        }
        private void ProcessTimerEventMarshaled()
        {
          if (!IsMouseInWindow())
          {
            --_countDown;
            if (_countDown == 0)
            {
              _timer.Close();
              this.Close();
            }
          }
          else
          {
            _countDown = 5;
          }
        }
        private bool IsMouseInWindow()
        {
          Point clientPoint = PointToClient(Cursor.Position);
          return ClientRectangle.Contains(clientPoint);
        }
      }
    }
