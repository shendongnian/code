    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    class MainUIThreadForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUIThreadForm());
        }
    
        IntPtr secondThreadFormHandle;
        public MainUIThreadForm()
        {
            Text = "First UI";
            Button button;
            Controls.Add(button = new Button { Text = "Start second UI thread", AutoSize = true, Location = new Point(10, 10) });
            button.Click += (s, e) =>
                {
                    if (secondThreadFormHandle == IntPtr.Zero)
                    {
                        Form second = SecondUIThreadForm.Create();
                        second.HandleCreated += SecondFormHandleCreated;
                        second.HandleDestroyed += SecondFormHandleDestroyed;
                    }
                };
            Controls.Add(button = new Button { Text = "Stop second UI thread", AutoSize = true, Location = new Point(10, 40) });
            button.Click += (s, e) =>
                {
                    if (secondThreadFormHandle != IntPtr.Zero)
                        PostMessage(secondThreadFormHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                };
        }
    
        void SecondFormHandleCreated(object sender, EventArgs e)
        {
            secondThreadFormHandle = (sender as Control).Handle;
        }
    
        void SecondFormHandleDestroyed(object sender, EventArgs e)
        {
            secondThreadFormHandle = IntPtr.Zero;
            Control second = sender as Control;
            second.HandleCreated -= SecondFormHandleCreated;
            second.HandleDestroyed -= SecondFormHandleDestroyed;
        }
    
        const int WM_CLOSE = 0x0010;
        [DllImport("User32.dll")]
        extern static IntPtr PostMessage(IntPtr hWnd, int message, IntPtr wParam, IntPtr lParam);
    }
    
    class SecondUIThreadForm : Form
    {
        static void Main2(object state)
        {
            Application.Run((Form)state);
        }
    
        public static SecondUIThreadForm Create()
        {
            SecondUIThreadForm form = new SecondUIThreadForm();
            Thread thread = new Thread(Main2);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(form);
            return form;
        }
    
        public SecondUIThreadForm()
        {
            Text = "Second UI";
        }
    }
