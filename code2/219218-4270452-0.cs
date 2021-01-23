    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;
    
    namespace Sandbox_Form
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                bw = new BackgroundWorker();
                bw.DoWork +=new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            }
    
            void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if(e.Error != null)
                    MessageBox.Show(e.Error.ToString() + "Mail Sending Fail's") ;
                else
                    MessageBox.Show("Mail Send Successfully");
            }
    
            BackgroundWorker bw;
    
            void bw_DoWork(object sender, DoWorkEventArgs e)
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
                sC.Send(message);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                bw.RunWorkerAsync();
            }
        }
    
    }
    
