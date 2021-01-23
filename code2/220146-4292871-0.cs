    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    
    public class Redirect
    {
        [STAThread()]
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
    
            Console.SetOut(sw); // redirect
            Console.WriteLine("We are redirecting standard output now...");
    
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            sw.Close();
    
            StringReader sr = new StringReader(sb.ToString());
            string completeString;
    
            completeString = sr.ReadToEnd();
            sr.Close();
    
            Clipboard.SetText(sb.ToString());
            Console.ReadKey(); // just wait... (press ctrl+v afterwards)
        }
    }
