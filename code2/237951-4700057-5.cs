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
    
        private IntPtr secondThreadFormHandle;
    
        public MainUIThreadForm()
        {
            Text = "First UI";
            Button button;
            Controls.Add(button = new Button { Name = "Start", Text = "Start second UI thread", AutoSize = true, Location = new Point(10, 10) });
            button.Click += (s, e) =>
            {
                if (secondThreadFormHandle == IntPtr.Zero)
                {
                    Form form = new Form
                    {
                        Text = "Second UI",
                        Location = new Point(Right, Top),
                        StartPosition = FormStartPosition.Manual,
                    };
                    form.HandleCreated += SecondFormHandleCreated;
                    form.HandleDestroyed += SecondFormHandleDestroyed;
                    form.RunInNewThread(false);
                }
            };
            Controls.Add(button = new Button { Name = "Stop", Text = "Stop second UI thread", AutoSize = true, Location = new Point(10, 40), Enabled = false });
            button.Click += (s, e) =>
            {
                if (secondThreadFormHandle != IntPtr.Zero)
                    PostMessage(secondThreadFormHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            };
        }
    
        void EnableStopButton(bool enabled)
        {
            if (InvokeRequired)
                BeginInvoke((Action)(() => EnableStopButton(enabled)));
            else
            {
                Control stopButton = Controls["Stop"];
                if (stopButton != null)
                    stopButton.Enabled = enabled;
            }
        }
    
        void SecondFormHandleCreated(object sender, EventArgs e)
        {
            Control second = sender as Control;
            secondThreadFormHandle = second.Handle;
            second.HandleCreated -= SecondFormHandleCreated;
            EnableStopButton(true);
        }
    
        void SecondFormHandleDestroyed(object sender, EventArgs e)
        {
            Control second = sender as Control;
            secondThreadFormHandle = IntPtr.Zero;
            second.HandleDestroyed -= SecondFormHandleDestroyed;
            EnableStopButton(false);
        }
    
        const int WM_CLOSE = 0x0010;
        [DllImport("User32.dll")]
        extern static IntPtr PostMessage(IntPtr hWnd, int message, IntPtr wParam, IntPtr lParam);
    }
    internal static class FormExtensions
    {
        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }
    
        public static void RunInNewThread(this Form form, bool isBackground)
        {
            if (form == null)
                throw new ArgumentNullException("form");
            if (form.IsHandleCreated)
                throw new InvalidOperationException("Form is already running.");
            Thread thread = new Thread(ApplicationRunProc);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = isBackground;
            thread.Start(form);
        }
    }
