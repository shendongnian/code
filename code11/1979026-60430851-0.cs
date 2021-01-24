    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace eNtsaTrainingRegistration
    {
        public class Helper_b
        {
            private const string PassPhrase = "3pAc0j$_56K?_S7c9gS!";
    
            //Encrypt password.
            public static string Encrypt(string strValue)
            {
                byte[] results;
                UTF8Encoding uTF8 = new UTF8Encoding();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] deskey = md5.ComputeHash(uTF8.GetBytes(PassPhrase));
                TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
                desalg.Key = deskey;
                desalg.Mode = CipherMode.ECB;
                desalg.Padding = PaddingMode.PKCS7;
                byte[] encrypt_data = uTF8.GetBytes(strValue);
    
                try
                {
                    ICryptoTransform encrytor = desalg.CreateEncryptor();
                    results = encrytor.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length);
                }
                finally
                {
                    desalg.Clear();
                    md5.Clear();
                }
                return Convert.ToBase64String(results);
            }
    
            //Decrypt password.
    
            public static string Decrypt(string strValue)
            {
                byte[] results;
                UTF8Encoding uTF8 = new UTF8Encoding();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] deskey = md5.ComputeHash(uTF8.GetBytes(PassPhrase));
                TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
                desalg.Key = deskey;
                desalg.Mode = CipherMode.ECB;
                desalg.Padding = PaddingMode.PKCS7;
                byte[] decrypt_data = Convert.FromBase64String(strValue);
                try
                {
                    ICryptoTransform decryptor = desalg.CreateDecryptor();
                    results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
                }
                finally
                {
                    desalg.Clear();
                    md5.Clear();
                }
                return uTF8.GetString(results);
            }
    
            // In between space
            public static string GetBetween(string strSource, string strStart, string strEnd)
            {
                int Start, End;
                if(strSource.Contains(strStart) && strSource.Contains(strEnd))
                {
                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    return strSource.Substring(Start, End - Start);
                }else
                {
                    return "";
                }
            }
            public static string BytesToString(long byteCount)
            {
                string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
                if (byteCount == 0)
                    return string.Format("{0} {1}", 0, suf[0]);
                long bytes = Math.Abs(byteCount);
                int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
                double num = Math.Round(bytes / Math.Pow(1024, place), 1);
                return string.Format("{0} {1}", (Math.Sign(byteCount) * num).ToString(), suf[place]);
            }
        }
    }
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using eNtsaTrainingRegistration.Models;
    using System.Net.Mail;
    
    using System.Net;
    using System.Web.Configuration;
    
    namespace eNtsaTrainingRegistration
    {
        public class EmailService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                var mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(message.Destination));
                mailMessage.From = new MailAddress("Gcobani Mkontwana <ggcobani@gmail.com>");
                mailMessage.Subject = message.Subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = message.Body;
    
                using(var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = WebConfigurationManager.AppSettings["UserName"],
                        Password = Helper_b.Decrypt(WebConfigurationManager.AppSettings["UserPassword"])
                    };
                    smtp.Credentials = credential;
                    smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
                return Task.FromResult(0);
            } 
            }
            
        }
