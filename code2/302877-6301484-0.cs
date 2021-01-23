        /// <summary>
        /// SMTP服务发送邮件
        /// </summary>
        /// <param name="mailSubjct">邮件主题</param>
        /// <param name="mailBody">邮件内容(html)</param>
        /// <param name="mailFrom">发件地址</param>
        /// <param name="mailAddress">收件地址</param>
        /// <param name="hostIp">SMTP主机IP</param>
        /// <param name="username">SMTP用户名</param>
        /// <param name="password">SMTP密码</param>
        /// <param name="ssl">是否启用SSL方式</param>
        /// <param name="port">SMTP端口</param>
        /// <returns></returns>
        public static string SendMail(string mailSubjct, string mailBody, string mailFrom, List<string> mailAddress, string hostIp, string username, string password, bool ssl, int port)
        {
            string error = string.Empty;
            try
            {
                MailMessage mm = new MailMessage();
                mm.IsBodyHtml = false;
                mm.Subject = mailSubjct;
                mm.BodyEncoding = Encoding.UTF8;
                mm.Body = mailBody;
                mm.IsBodyHtml = true;
                mm.From = new MailAddress(mailFrom, Const.SYS_NAME, Encoding.UTF8);
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                for (int i = 0; i < mailAddress.Count; i++)
                {
                    if (regex.IsMatch(mailAddress[i]))
                    {
                        mm.To.Add(mailAddress[i]);
                    }
                }
                if (mm.To.Count == 0)
                {
                    return string.Empty;
                }
                SmtpClient sc = new SmtpClient();
                NetworkCredential nc = new NetworkCredential(username, password);
                sc.EnableSsl = ssl;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nc;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Host = hostIp;
                sc.Port = port;
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }
