    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using BackgroundApp.Properties;
    
    namespace BackgroundApp
    {
        static class Program
        {
            /// <summary>
     
       /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationStartUp());
        }
    }
    public class ApplicationStartUp : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private void InitializeComponent()
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayIcon = new NotifyIcon();
            trayIcon.Text = Resources.TrayIcon;
            trayIcon.Icon = new                            Icon(global::BackgroundApp.Properties.Resources.IntegratedServer, 40, 40);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }
       
        //Ctor
        public ApplicationStartUp()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }
        private void OnExit(object sender, EventArgs e)
        {
            // Release the icon resource.
            trayIcon.Dispose();
            Application.Exit();
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }
            base.Dispose(isDisposing);
        }
    }
