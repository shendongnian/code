    public class Test
    {
        public static String RandomNum1;
        /// <summary>
        /// Start method for Job
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            RandomNum1 = new Random().Next(9999).ToString() + " ";
            MailHandler2 mh = new MailHandler2();
            mh.SendJobStartUpdate();
        }
    }
    public class MailHandler2
    {
        String RandomNum;
        public MailHandler2()
        {
            //Thread.Sleep(1000);
            RandomNum = new Random().Next(9999).ToString() + " ";
        }
        public void SendJobStartUpdate()
        {
            try
            {
                var mail = new MailMessage();
                mail.To.Add("lijo.john@urmail.com");
                mail.Subject = "Job  Started " + RandomNum + "  -  " + DateTime.Now;
                mail.Body = "<br/>Job  Started...";
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception c)
                    {
                        throw c;
                    }
                }
            }
            catch (FormatException eF)
            {
            }
        }
    }
