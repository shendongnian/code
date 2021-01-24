    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Net;
    
    namespace SendMsgByFCM
    {
        public partial class Form1 : Form
        {
         
            AndroidGCMPushNotification fcmPush = new AndroidGCMPushNotification();
    
          
            public Form1()
            {
                InitForm();
                InitializeComponent();
             
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                 *devId* = "faxgYiWv4Sk:APA91bGehlGNNGaE20djfaJ5xzQst_b190GvrEwm_yvPsZvY-.....";
                fcmPush.SendNotification(devId, 'message ...' );
                MessageBox.Show( "msg send" );
            }
        }
    
        public class AndroidGCMPushNotification
        {
           
            public string SendNotification(string deviceId, string message)
            {
                string **SERVER_API_KEY** = "AAAADtSR7s8:APA91bHhhsjRMeL2gH6Qzv5BbdJyshOtgJ-J....";
                
                var **SENDER_ID** = "636988888888";
                var value = message;
                WebRequest tRequest;
                tRequest = **WebRequest.Create**("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
    
                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
    
                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";
                Console.WriteLine(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;
    
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
    
                WebResponse tResponse = tRequest.GetResponse();
    
                dataStream = tResponse.GetResponseStream();
    
                StreamReader tReader = new StreamReader(dataStream);
    
                String sResponseFromServer = tReader.ReadToEnd();
    
    
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                return sResponseFromServer;
            }
        }
    }
