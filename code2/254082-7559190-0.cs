    using System.Net.Mail;
    using System.Net;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            MailMessage oMail = new MailMessage(new MailAddress("username@yahoo.com"), new MailAddress("username@yahoo.com"));
            SmtpClient oSmtp = new SmtpClient();
            oSmtp.Host = "smtp.mail.yahoo.com";
            oSmtp.Credentials = new NetworkCredential("username", "password");
            oSmtp.EnableSsl = false;
            oSmtp.Port = 587;
            oSmtp.Send(oMail);
        }
    }
