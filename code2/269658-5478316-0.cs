    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        static class Program
        {
    
            private static Timer _idleTimer;
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                _idleTimer = new Timer();
                _idleTimer.Tick += new EventHandler(_idleTimer_Tick);
                _idleTimer.Interval = (5 * 60) * 1000; // (5 minutes * seconds) * milliseconds
    
                Application.AddMessageFilter(new MouseMessageFilter(UserIsActive));
                Application.AddMessageFilter(new KeyboardMessageFilter(UserIsActive));
    
                Application.Run(new Form1());
            }
    
            static void _idleTimer_Tick(object sender, EventArgs e)
            {
                MessageBox.Show("You are idle for " + _idleTimer.Interval.ToString() + " milliseconds");
            }
    
            static void UserIsActive(object sender, EventArgs e)
            {
                _idleTimer.Stop();
                _idleTimer.Start();
            }
    
            public class MouseMessageFilter : IMessageFilter
            {
                private EventHandler _callback;
    
                public MouseMessageFilter(EventHandler callback)
                {
                    _callback = callback;
                }
    
                private const int WM_MOUSEMOVE = 0x0200;
    
                public bool PreFilterMessage(ref Message m)
                {
                    if (m.Msg == WM_MOUSEMOVE)
                    {
                        _callback(null, null);
                    }
    
                    return false;
                }
            }
    
            private class KeyboardMessageFilter : IMessageFilter
            {
                private EventHandler _callback;
    
                public KeyboardMessageFilter(EventHandler callback)
                {
                    _callback = callback;
                }
    
                const int WM_KEYDOWN = 0x100;
                const int WM_KEYUP = 0x0101;
                const int WM_SYSKEYDOWN = 0x104;
                const int WM_SYSKEYUP = 0x0105;
    
                #region IMessageFilter Members
    
                public bool PreFilterMessage(ref Message m)
                {
                    if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                    {
                        _callback(null, null);
                    }
    
                    if ((m.Msg == WM_KEYUP) || (m.Msg == WM_SYSKEYUP))
                    {
                        _callback(null, null);
                    }
    
                    return false;
                }
    
                #endregion
            }
    
        }
    }
