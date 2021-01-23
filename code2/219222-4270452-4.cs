    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("myid@yahoo.com");
                message.To.Add("anotherid@yahoo.com");
                message.Subject = "afdasdfasfg";
                message.Body = "Hgfk4564267862738I";
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient sC = new SmtpClient("smtp.mail.yahoo.com");
                sC.Port = 587;
                sC.Credentials = new NetworkCredential("myid", "mypassword");
                //sC.EnableSsl = true;
                //sC.Send(message);
                sC.SendCompleted += new SendCompletedEventHandler(sC_SendCompleted);
                sC.SendAsync(message, null);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Mail Sending Fail's");
            }
        }
        void sC_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error != null)
                MessageBox.Show(ex + "Mail Sending Fail's");
            else
                MessageBox.Show("Mail Send Successfully");
        }
    }
