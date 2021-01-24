        static void Main(string[] args) {
            UTF8Encoding utf8 = new UTF8Encoding();
            Encoding w1252 = Encoding.GetEncoding(1252);
            string inbuf = "Rule(s): Global Tag â€“ Refer to Print Rules â€“ General Requirements";
            byte[] bytearray = utf8.GetBytes(inbuf);
            byte[] outbytes = Encoding.Convert(utf8, w1252, bytearray);
            Debug.WriteLine("*************************");
            Debug.WriteLine(String.Format("  Input: {0}", inbuf));
            Debug.WriteLine(String.Format(" Output: {0}", utf8.GetString(outbytes)));
            Debug.WriteLine("*************************");
        }//Main()
*************************
  Input: Rule(s): Global Tag â€“ Refer to Print Rules â€“ General Requirements
 Output: Rule(s): Global Tag – Refer to Print Rules – General Requirements
*************************
