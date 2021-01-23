    static class Program
    {
        private static ApplicationContext _context;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (_context = new ApplicationContext())
            {
                var message = new OutlookMailMessage();
                message.Closed += new EventHandler(message_Closed);
                Application.Run(_context);
            }
        }
        static void message_Closed(object sender, EventArgs e)
        {
            // Perform processing after the message has been send or closed.
            _context.ExitThread();
        }
    }
