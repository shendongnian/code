    using System;
    using System.Net;
    using System.Timers;
    using System.Xml;
    namespace Gmail_final_prep 
    { 
    public class Gmail_FP 
    { 
        private static System.Timers.Timer gTimer; 
 
        public static void GMain() 
        { 
            gTimer = new System.Timers.Timer(2000); 
 
            // Hook up the Elapsed event for the timer. 
            gTimer.Elapsed += OnTimedEvent1; 
 
            gTimer.Interval = 2000; 
            gTimer.Enabled = true; 
 
            Console.WriteLine("Press the Enter key to exit the program."); 
            Console.ReadLine(); 
 
            // If the timer is declared in a long-running method, use 
            // KeepAlive to prevent garbage collection from occurring 
            // before the method ends. 
            //GC.KeepAlive(gTimer); 
        } 
 
        private static void OnTimedEvent1(object source, ElapsedEventArgs e) 
        { // { expected here 
            CheckMail();
        }
        public static string TextToBase64(string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }
        public static string CheckMail()
        {
            string result = "0";
            try
            {
                var url = @"https://gmail.google.com/gmail/feed/atom";
                var USER = "usr";
                var PASS = "pss";
                var encoded = TextToBase64(USER + ":" + PASS);
                var myWebRequest = HttpWebRequest.Create(url);
                myWebRequest.Method = "POST";
                myWebRequest.ContentLength = 0;
                myWebRequest.Headers.Add("Authorization", "Basic " + encoded);
                var response = myWebRequest.GetResponse();
                var stream = response.GetResponseStream();
                XmlReader reader = XmlReader.Create(stream);
                System.Text.StringBuilder gml = new System.Text.StringBuilder();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                        if (reader.Name == "fullcount")
                        {
                            gml.Append(reader.ReadElementContentAsString()).Append(",");
                            //result = reader.ReadElementContentAsString(); 
                            //return result; 
                        }
                }
                Console.WriteLine(gml.ToString());
            }
            catch (Exception ee) { Console.WriteLine(ee.Message); }
            return result;
        } 
    } 
    } // Type or namespace definition, or end-of-file expected here 
